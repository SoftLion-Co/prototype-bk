using BLL.DTOs.CountryDTO;
using DAL.Entities.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Country
{
    public interface ICountryService
    {
        Task<ResponseEntity<IEnumerable<GetCountryDTO>>> GetAllCountriesAsync();
        Task<ResponseEntity<GetCountryDTO>> GetCountryByIdAsync(Guid id);
        Task<ResponseEntity<GetCountryDTO>> InsertCountryAsync(InsertCountryDTO blogDTO);
        Task<ResponseEntity<GetCountryDTO>> UpdateCountryAsync(UpdateCountryDTO updateCountryDTO);
        Task<ResponseEntity<IEnumerable<GetCountryDTO>>> DeleteCountryByIdAsync(Guid id);
    }
}
