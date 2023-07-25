using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.CreateAuthor
{
    public record CreateAuthorCommand(InsertAuthorDTO authorDTO) : IRequest<ResponseEntity<GetAuthorDTO>>;
}
