using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.GetAuthorById
{
    public record GetAuthorByIdQuery(Guid id) : IRequest<ResponseEntity<GetAuthorDTO>>;
}
