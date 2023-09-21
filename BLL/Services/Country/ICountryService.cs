using BLL.DTOs.CountryDTO;
using BLL.DTOs.Response;

namespace BLL.Services.Country
{
    public interface ICountryService
    {
        Task<ResponseEntity<IEnumerable<GetCountryDTO>>> GetAllCountriesAsync();
        Task<ResponseEntity<GetCountryDTO>> GetCountryByIdAsync(Guid id);
        Task<ResponseEntity<GetCountryDTO>> InsertCountryAsync(InsertCountryDTO insertCountryDTO);
        Task<ResponseEntity<GetCountryDTO>> UpdateCountryAsync(UpdateCountryDTO updateCountryDTO);
        Task<ResponseEntity> DeleteCountryByIdAsync(Guid id);
    }
}
