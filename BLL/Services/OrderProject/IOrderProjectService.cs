using BLL.DTOs.OrderProjectDTO;
using BLL.DTOs.Response;

namespace BLL.Services.OrderProject
{
    public interface IOrderProjectService
    {
        Task<ResponseEntity<IEnumerable<GetOrderProjectDTO>>> GetAllOrderProjectsAsync();
        Task<ResponseEntity<GetOrderProjectDTO>> GetOrderProjectByIdAsync(Guid id);
        Task<ResponseEntity<GetOrderProjectDTO>> InsertOrderProjectAsync(InsertOrderProjectDTO insertOrderProjectDTO);
        Task<ResponseEntity<GetOrderProjectDTO>> UpdateOrderProjectAsync(UpdateOrderProjectDTO updateOrderProjectDTO);
        Task<ResponseEntity> DeleteOrderProjectByIdAsync(Guid id);
        Task<ResponseEntity<GetOrderProjectDTO>> ChangeTypeOrderAsync(Guid id, int typeNumber);
    }
}
