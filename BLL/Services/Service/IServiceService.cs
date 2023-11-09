
using BLL.DTOs.ServiceDTO;
using BLL.DTOs.Response;

namespace BLL.Services.Service
{
    public interface IServiceService
    {
        Task<ResponseEntity<IEnumerable<GetServiceDTO>>> GetAllCountriesAsync();
        Task<ResponseEntity<GetServiceDTO>> GetServiceByIdAsync(Guid id);
        Task<ResponseEntity<GetServiceDTO>> InsertServiceAsync(InsertServiceDTO insertServiceDTO);
        Task<ResponseEntity<GetServiceDTO>> UpdateServiceAsync(UpdateServiceDTO updateServiceDTO);
        Task<ResponseEntity> DeleteServiceByIdAsync(Guid id);
    }
}
