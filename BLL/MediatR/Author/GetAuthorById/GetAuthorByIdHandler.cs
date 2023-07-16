using BLL.DTOs.AuthorDTO;
using BLL.Services.Author;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.GetAuthorById
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, ResponseEntity<GetAuthorDTO>>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorByIdHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public  Task<ResponseEntity<GetAuthorDTO>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return _authorService.GetAuthorByIdAsync(request.id);
        }
    }
}
