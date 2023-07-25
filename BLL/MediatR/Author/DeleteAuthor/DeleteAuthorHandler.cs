using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Services.Author;
using MediatR;

namespace BLL.MediatR.Author.DeleteAuthor
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, ResponseEntity>
    {
        private readonly IAuthorService _authorService;

        public DeleteAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public Task<ResponseEntity> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return _authorService.DeleteAuthorByIdAsync(request.Id);
        }
    }
}
