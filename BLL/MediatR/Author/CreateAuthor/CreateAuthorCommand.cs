using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.CreateAuthor
{
    public record CreateAuthorCommand(InsertAuthorDTO authorDTO) : IRequest<ResponseEntity<GetAuthorDTO>>;
}
