using BLL.DTOs.CountryDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Country.UpdateCountry
{
    public record UpdateCountryCommand(UpdateCountryDTO UpdateCountryDTO) : IRequest<ResponseEntity<GetCountryDTO>>;
}
