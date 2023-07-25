using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Services.Author;
using MediatR;

namespace BLL.MediatR.Author.UpdateAuthor
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, ResponseEntity<GetAuthorDTO>>
    {
        private readonly IAuthorService _authorService;

        public UpdateAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public Task<ResponseEntity<GetAuthorDTO>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return _authorService.UpdateAuthorAsync(request.UpdateAuthorDTO);
        }
    }
}
