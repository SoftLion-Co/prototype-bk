using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author
{
    public record GetAllAuthorsQuery() : IRequest<ResponseEntity<IEnumerable<GetAuthorDTO>>>;
}
