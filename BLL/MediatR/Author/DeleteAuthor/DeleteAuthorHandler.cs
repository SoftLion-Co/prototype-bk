using BLL.DTOs.AuthorDTO;
using BLL.Services.Author;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.DeleteAuthor
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, ResponseEntity<IEnumerable<GetAuthorDTO>>>
    {
        private readonly IAuthorService _authorService;

        public DeleteAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return _authorService.DeleteAuthorByIdAsync(request.Id);
        }
    }
}
