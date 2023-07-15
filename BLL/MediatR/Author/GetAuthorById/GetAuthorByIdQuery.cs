using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.GetAuthorById
{
    public record GetAuthorByIdQuery(Guid id) : IRequest<ResponseEntity<GetAuthorDTO>>;
}
