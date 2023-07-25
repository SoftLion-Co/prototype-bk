using BLL.DTOs.CountryDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Services.Country;
using MediatR;

namespace BLL.MediatR.Country.GetByIdCountry
{
    public class GetByIdCountryHandler : IRequestHandler<GetByIdCountryCommand, ResponseEntity<GetCountryDTO>>
    {
        private readonly ICountryService _countryService;

        public GetByIdCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<ResponseEntity<GetCountryDTO>> Handle(GetByIdCountryCommand request, CancellationToken cancellationToken)
        {
            return await _countryService.GetCountryByIdAsync(request.id);
        }
    }
}
