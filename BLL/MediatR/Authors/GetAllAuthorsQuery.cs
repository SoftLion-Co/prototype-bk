using BLL.DTOs.RequestDTOs;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Authors
{
    public record GetAllAuthorsQuery() : IRequest<ResponseEntity<IEnumerable<AuthorDTO>>>;
}
