using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.GetAllTopAuthors
{
    public record GetAllTopAuthorsQuery() : IRequest<ResponseEntity<IEnumerable<GetTopAuthorDTO>>>;
}
