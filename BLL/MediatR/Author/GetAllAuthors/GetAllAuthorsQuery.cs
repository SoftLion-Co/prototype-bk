using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.GetAllAuthors
{
    public record GetAllAuthorsQuery() : IRequest<ResponseEntity<IEnumerable<GetAuthorDTO>>>;
}
