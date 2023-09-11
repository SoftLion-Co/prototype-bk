using System.Collections;
using System.Linq.Expressions;
using System.Net;
using AutoMapper;
using BLL.AutoMapper;
using BLL.DTOs.AuthorDTO;
using BLL.Services.Author;
using DAL.Entities;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore.Query;
using Moq;

namespace SoftLionNUnitTests;

[TestFixture]
public class GetAuthorsServiceTests
{
    private readonly Mock<IMapper> _mapperMock;

    private readonly Mock<IWrapperRepository> _mockWrapperRepository;

    private readonly AuthorService _authorService;

    public GetAuthorsServiceTests()
    {
        _mockWrapperRepository = new Mock<IWrapperRepository>();
        _mockWrapperRepository.Setup(repo => repo.AuthorRepository.GetAllAsync(
                It.IsAny<Expression<Func<Author, Author>>>(),
                It.IsAny<Expression<Func<Author, bool>>>(),
                It.IsAny<Func<IQueryable<Author>, IIncludableQueryable<Author, object>>>()))
            .ReturnsAsync(GetAuthors);
        
        _mapperMock = new Mock<IMapper>();
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<GetAuthorDTO>>(It.IsAny<IEnumerable<Author>>()))
            .Returns(GetAuthorDtos);

        _authorService = new AuthorService(_mockWrapperRepository.Object, _mapperMock.Object);
    }
    
    [Test]
    public async Task GetAllAuthorsAsync_ShouldReturnListOfAuthorDTOs()
    {
        // Act
        var result = await _authorService.GetAllAuthorsAsync();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            Assert.That(result.Result, Is.TypeOf(typeof(List<GetAuthorDTO>)));
            CollectionAssert.AreEqual(GetAuthorDtos(), result.Result, new AuthorComparer());
        });
        
        _mapperMock.Verify(m => m.Map<IEnumerable<GetAuthorDTO>>(It.IsAny<IEnumerable<Author>>()), Times.Once);
        _mockWrapperRepository.Verify(w => w.AuthorRepository.GetAllAsync(
            It.IsAny<Expression<Func<Author, Author>>>(),
            It.IsAny<Expression<Func<Author, bool>>>(),
            It.IsAny<Func<IQueryable<Author>, IIncludableQueryable<Author, object>>>()), Times.Once);
    }

    private static IEnumerable<GetAuthorDTO> GetAuthorDtos()
    {
        return new List<GetAuthorDTO>
        {
            new() { Id = Guid.Parse("1ca29d40-68be-42a2-84c3-9ac695f9cf5e"), Name = "Author 1" },
            new() { Id = Guid.Parse("5962837b-ac6f-4a21-a161-588921f1fab2"), Name = "Author 2" }
        };
    }

    private static IEnumerable<Author> GetAuthors()
    {
        return new List<Author>
        {
            new() { Id = Guid.Parse("1ca29d40-68be-42a2-84c3-9ac695f9cf5e"), Name = "Author 1" },
            new() { Id = Guid.Parse("5962837b-ac6f-4a21-a161-588921f1fab2"), Name = "Author 2" }
        };
    }

    private class AuthorComparer : IComparer
    {
        public int Compare(object? author1, object? author2)
        {
            var x = (GetAuthorDTO)author1;
            var y = (GetAuthorDTO)author2;
            
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            var nameComparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            var surnameComparison = string.Compare(x.Surname, y.Surname, StringComparison.Ordinal);
            if (surnameComparison != 0) return surnameComparison;
            var employmentComparison = string.Compare(x.Employment, y.Employment, StringComparison.Ordinal);
            if (employmentComparison != 0) return employmentComparison;
            var avatarComparison = string.Compare(x.Avatar, y.Avatar, StringComparison.Ordinal);
            if (avatarComparison != 0) return avatarComparison;
            return string.Compare(x.Description, y.Description, StringComparison.Ordinal);
        }
    }

}