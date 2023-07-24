using BLL.DTOs.CountryDTO;
using BLL.MediatR.Country.CreateCountry;
using BLL.Services.Country;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Country.CreateCountry
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, ResponseEntity<GetCountryDTO>>
    {
        private readonly ICountryService _countryService;
        public CreateCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public Task<ResponseEntity<GetCountryDTO>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            return _countryService.InsertCountryAsync(request.countryDto);
        }
    }
}
