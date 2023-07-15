using AutoMapper;
using BLL.DTOs.AuthorDTO;
using BLL.Services.Author;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;
using MediatR;

namespace BLL.MediatR.Author.GetAllAuthors
{
    public class GetAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, ResponseEntity<IEnumerable<GetAuthorDTO>>>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorsHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {

            var authorDTOs = await _authorService.GetAllAuthorsAsync();

            return authorDTOs;
        }
    }
}
