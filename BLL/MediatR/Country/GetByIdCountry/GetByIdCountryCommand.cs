using BLL.DTOs.CountryDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Country.GetByIdCountry
{
    public record GetByIdCountryCommand(Guid id) : IRequest<ResponseEntity<GetCountryDTO>>;
}
