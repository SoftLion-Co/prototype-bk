using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.DeleteAuthor
{
    public record DeleteAuthorCommand(Guid Id) : IRequest<ResponseEntity>;
}
