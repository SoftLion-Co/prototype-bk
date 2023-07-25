using BLL.DTOs.Response.ResponseEntity;
using BLL.Services.Country;
using MediatR;

namespace BLL.MediatR.Country.DeleteCountry
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, ResponseEntity>
    {
        private readonly ICountryService _countryService;
        public DeleteCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public Task<ResponseEntity> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                return _countryService.DeleteCountryByIdAsync(request.Id);
            }
        
    }
}
