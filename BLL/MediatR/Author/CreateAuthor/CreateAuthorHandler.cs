using BLL.DTOs.AuthorDTO;
using BLL.Services.Author;
using DAL.Entities.ResponseEntity;
using MediatR;


namespace BLL.MediatR.Author.CreateAuthor
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, ResponseEntity<GetAuthorDTO>>
    {
        private readonly IAuthorService _authorService;
        public CreateAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public Task<ResponseEntity<GetAuthorDTO>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            return _authorService.InsertAuthorAsync(request.authorDTO);
        }
    }
}
