
using BLL.DTOs.PeriodProgressDTO;
using BLL.DTOs.Response;

namespace BLL.Services.PeriodProgress
{
    public interface IPeriodProgressService
    {
        Task<ResponseEntity<IEnumerable<GetPeriodProgressDTO>>> GetAllPeriodProgresssAsync();
        Task<ResponseEntity<GetPeriodProgressDTO>> GetPeriodProgressByIdAsync(Guid id);
        Task<ResponseEntity<GetPeriodProgressDTO>> InsertPeriodProgressAsync(InsertPeriodProgressDTO insertPeriodProgressDTO);
        Task<ResponseEntity<GetPeriodProgressDTO>> UpdatePeriodProgressAsync(UpdatePeriodProgressDTO updatePeriodProgressDTO);
        Task<ResponseEntity> DeletePeriodProgressByIdAsync(Guid id);
        
    }
}
