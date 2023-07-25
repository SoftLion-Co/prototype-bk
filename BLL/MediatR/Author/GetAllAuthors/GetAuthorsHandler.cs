using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Services.Author;
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
            return await _authorService.GetAllAuthorsAsync();
        }
    }
}
