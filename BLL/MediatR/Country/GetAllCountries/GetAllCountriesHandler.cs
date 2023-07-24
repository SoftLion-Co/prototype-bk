using BLL.DTOs.CountryDTO;
using BLL.MediatR.Country.DeleteCountry;
using BLL.Services.Country;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Country.GetAllCountries
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesCommand,
       ResponseEntity<IEnumerable<GetCountryDTO>>>
    {
        private readonly ICountryService _countryService;
        public GetAllCountriesHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<ResponseEntity<IEnumerable<GetCountryDTO>>> Handle(GetAllCountriesCommand request, CancellationToken cancellationToken)
        {
            return await _countryService.GetAllCountriesAsync();
        }
    }
    
        
       

    
}
