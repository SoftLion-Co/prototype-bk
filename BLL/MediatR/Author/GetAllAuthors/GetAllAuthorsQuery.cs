using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Author.GetAllAuthors
{
    public record GetAllAuthorsQuery() : IRequest<ResponseEntity<IEnumerable<GetAuthorDTO>>>;
}
