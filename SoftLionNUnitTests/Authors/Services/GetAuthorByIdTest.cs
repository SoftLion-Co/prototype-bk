using System.Linq.Expressions;
using System.Net;
using AutoMapper;
using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Exceptions;
using BLL.Services.Author;
using DAL.Entities;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore.Query;
using Moq;

namespace SoftLionNUnitTests.Authors.Services;

public class GetAuthorByIdTest
{
    private readonly Mock<IMapper> _mapperMock;

    private readonly Mock<IWrapperRepository> _mockWrapperRepository;

    private readonly AuthorService _authorService;

    public GetAuthorByIdTest()
    {
        _mockWrapperRepository = new Mock<IWrapperRepository>();
        _mockWrapperRepository.Setup(repo => repo.AuthorRepository.GetEntityByIdAsync(
                It.Is<Guid>(id => id.Equals(Guid.Parse("1ca29d40-68be-42a2-84c3-9ac695f9cf5e"))),
                It.IsAny<Expression<Func<Author, Author>>>(),
                It.IsAny<Expression<Func<Author, bool>>>(),
                It.IsAny<Func<IQueryable<Author>, IIncludableQueryable<Author, object>>>()))
            .ReturnsAsync(GetAuthor);
        
        _mockWrapperRepository.Setup(repo => repo.AuthorRepository.GetEntityByIdAsync(
                It.Is<Guid>(id => !id.Equals(Guid.Parse("1ca29d40-68be-42a2-84c3-9ac695f9cf5e"))),
                It.IsAny<Expression<Func<Author, Author>>>(),
                It.IsAny<Expression<Func<Author, bool>>>(),
                It.IsAny<Func<IQueryable<Author>, IIncludableQueryable<Author, object>>>()))
            .ReturnsAsync((Author)null!);
        
        _mapperMock = new Mock<IMapper>();
        _mapperMock.Setup(mapper => mapper.Map<GetAuthorDTO>
                (It.IsAny<Author>()))
            .Returns(GetAuthorDto);

        _authorService = new AuthorService(_mockWrapperRepository.Object, _mapperMock.Object);
    }
    
    [Test]
    [Order(2)]
    [TestCase("1ca29d40-68be-42a2-84c3-9ac695f9cf5e")]
    public async Task GetAuthorByIdAsync_ShouldReturnGetAuthorDTO(string id)
    {
        //Arrange
        var guid = Guid.Parse(id);
        
        //Act
        var result = await _authorService.GetAuthorByIdAsync(guid);
        
        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.TypeOf(typeof(GetAuthorDTO)));
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        });
    }

    [Test]
    [Order(1)]
    public void GetAuthorByNotExistingIdReturnsNotFoundExceptionTest()
    {
        //Arrange 
        var guid = Guid.NewGuid();
        
        //Act
        // var result = await _authorService.GetAuthorByIdAsync(guid);
        var exceptionDetails = Assert.ThrowsAsync<NotFoundException>(async () => await _authorService.GetAuthorByIdAsync(guid));

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(exceptionDetails!.Message, Is.Not.Null);
            Assert.That(exceptionDetails.StatusCode, Is.EqualTo((int)HttpStatusCode.NotFound));
            Assert.That(exceptionDetails.Errors.First().Message, Is.EqualTo($"{typeof(Author)} not found"));
        });
        
        _mapperMock.Verify(mapper => mapper.Map<GetAuthorDTO>
            (It.IsAny<Author>()), Times.Never());
    }

    private static GetAuthorDTO GetAuthorDto()
    {
        return new GetAuthorDTO
        {
             Id = Guid.Parse("1ca29d40-68be-42a2-84c3-9ac695f9cf5e"), Name = "Author 1" 
        };
    }

    private static Author GetAuthor()
    {
        return new Author { Id = Guid.Parse("1ca29d40-68be-42a2-84c3-9ac695f9cf5e"), Name = "Author 1" };
    }
}