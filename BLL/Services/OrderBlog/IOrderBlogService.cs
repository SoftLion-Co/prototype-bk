using BLL.DTOs.OrderBlogDTO;
using BLL.DTOs.Response;

namespace BLL.Services.OrderBlog
{
    public interface IOrderBlogService
    {
        Task<ResponseEntity<IEnumerable<GetOrderBlogDTO>>> GetAllOrderBlogsAsync();
        Task<ResponseEntity<GetOrderBlogDTO>> GetOrderBlogByIdAsync(Guid id);
        Task<ResponseEntity<GetOrderBlogDTO>> InsertOrderBlogAsync(InsertOrderBlogDTO insertOrderBlogDTO);
        Task<ResponseEntity<GetOrderBlogDTO>> UpdateOrderBlogAsync(UpdateOrderBlogDTO updateOrderBlogDTO);
        Task<ResponseEntity> DeleteOrderBlogByIdAsync(Guid id);
        Task<ResponseEntity<GetOrderBlogDTO>> ChangeTypeOrderAsync(Guid id, bool typeNumber);
    }
}
