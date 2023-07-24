﻿using BLL.DTOs.CountryDTO;
using DAL.Entities.ResponseEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MediatR.Country.DeleteCountry
{
    public record DeleteCountryCommand(Guid Id): IRequest<ResponseEntity<IEnumerable<GetCountryDTO>>>;
}