using BLL.DTOs.Response;
using BLL.DTOs.TechnologyDTO;

namespace BLL.Services.Technology
{
    public interface ITechnologyService
    {
        Task<ResponseEntity<IEnumerable<GetTechnologyDTO>>> GetAllTechnologiesAsync();
        Task<ResponseEntity<GetTechnologyDTO>> GetTechnologyByIdAsync(Guid id);
        Task<ResponseEntity<GetTechnologyDTO>> InsertTechnologyAsync(InsertTechnologyDTO blogDTO);
        Task<ResponseEntity<GetTechnologyDTO>> UpdateTechnologyAsync(UpdateTechnologyDTO updateTechnologyDTO);
        Task<ResponseEntity> DeleteTechnologyByIdAsync(Guid id);
    }
}
