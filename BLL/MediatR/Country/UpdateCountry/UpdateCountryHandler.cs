﻿using BLL.DTOs.CountryDTO;
using BLL.Services.Country;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Country.UpdateCountry
{
    public class GetByIdCountryHandler : IRequestHandler<UpdateCountryCommand, ResponseEntity<GetCountryDTO>>
    {
        private readonly ICountryService _countryService;

        public GetByIdCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<ResponseEntity<GetCountryDTO>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            return await _countryService.UpdateCountryAsync(request.UpdateCountryDTO);
        }
    }
}