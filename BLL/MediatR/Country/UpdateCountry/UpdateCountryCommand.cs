using BLL.DTOs.CountryDTO;
using DAL.Entities.ResponseEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MediatR.Country.UpdateCountry
{
    public record UpdateCountryCommand(UpdateCountryDTO UpdateCountryDTO) : IRequest<ResponseEntity<GetCountryDTO>>;
}
