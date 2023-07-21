using BLL.DTOs.AuthorDTO;
using BLL.Services.Author;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.GetAllTopAuthors
{
    public class GetAllTopAuthorsHandler : IRequestHandler<GetAllTopAuthorsQuery, ResponseEntity<IEnumerable<GetTopAuthorDTO>>>
    {
        private readonly IAuthorService _authorService;

        public GetAllTopAuthorsHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<ResponseEntity<IEnumerable<GetTopAuthorDTO>>> Handle(GetAllTopAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorService.GetAllTopAuthorsAsync();
        }
    }
}
