using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.DeleteAuthor
{
    public record DeleteAuthorCommand(Guid Id) : IRequest<ResponseEntity<IEnumerable<GetAuthorDTO>>>;
}
