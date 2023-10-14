
using BLL.DTOs.OrderProjectStatusDTO;
using BLL.DTOs.Response;

namespace BLL.Services.OrderProjectStatus
{
    public interface IOrderProjectStatusService
    {
        Task<ResponseEntity<IEnumerable<GetOrderProjectStatusDTO>>> GetAllOrderProjectStatusesAsync();
        Task<ResponseEntity<IEnumerable<GetOrderProjectStatusDTO>>> GetOrderProjectStatusByCustomerIdAsync(Guid customerId);
        Task<ResponseEntity<GetOrderProjectStatusDTO>> GetOrderProjectStatusByIdAsync(Guid id);
        Task<ResponseEntity<GetOrderProjectStatusDTO>> InsertOrderProjectStatusAsync(InsertOrderProjectStatusDTO insertOrderProjectStatusDTO);
        Task<ResponseEntity<GetOrderProjectStatusDTO>> UpdateOrderProjectStatusAsync(UpdateOrderProjectStatusDTO updateOrderProjectStatusDTO);
        Task<ResponseEntity> DeleteOrderProjectStatusByIdAsync(Guid id);
        Task<ResponseEntity<GetOrderProjectStatusDTO>> ChangeTypeAsync(Guid id, int typeNumber);
    }
}
