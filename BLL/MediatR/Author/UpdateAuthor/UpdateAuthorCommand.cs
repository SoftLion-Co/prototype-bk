using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.UpdateAuthor
{
    public record UpdateAuthorCommand(UpdateAuthorDTO UpdateAuthorDTO) : IRequest<ResponseEntity<GetAuthorDTO>>; 
}
