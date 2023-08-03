using BLL.DTOs.TechnologyDTO;
using BLL.DTOs.Response.ResponseEntity;

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
