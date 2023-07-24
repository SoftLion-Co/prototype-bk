using BLL.DTOs.CountryDTO;
using BLL.MediatR.Country.CreateCountry;
using BLL.Services.Country;
using DAL.Entities.ResponseEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MediatR.Country.DeleteCountry
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, ResponseEntity<IEnumerable<GetCountryDTO>>>
    {
        private readonly ICountryService _countryService;
        public DeleteCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public Task<ResponseEntity<IEnumerable<GetCountryDTO>>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                return _countryService.DeleteCountryByIdAsync(request.Id);
            }
        
    }
}
