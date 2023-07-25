using BLL.DTOs.CountryDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Country.GetAllCountries
{
    public record  GetAllCountriesCommand() : IRequest<ResponseEntity<IEnumerable<GetCountryDTO>>>;
        
}
