﻿using BLL.DTOs.Base;

namespace BLL.DTOs.CountryDTO
{
    public class UpdateCountryDTO : UpdateBaseDTO
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
