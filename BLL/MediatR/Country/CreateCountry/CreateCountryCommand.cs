using BLL.DTOs.CountryDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;


namespace BLL.MediatR.Country.CreateCountry
{
    public record CreateCountryCommand(InsertCountryDTO countryDto) : IRequest<ResponseEntity<GetCountryDTO>>;
}
