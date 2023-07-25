using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.UpdateAuthor
{
    public record UpdateAuthorCommand(UpdateAuthorDTO UpdateAuthorDTO) : IRequest<ResponseEntity<GetAuthorDTO>>; 
}
