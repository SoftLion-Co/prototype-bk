using BLL.DTOs.BlogDTO;
using DAL.Entities.ResponseEntity;

namespace BLL.Services.Blog
{
    public interface IBlogService
    {
        Task<ResponseEntity<IEnumerable<GetBlogDTO>>> GetAllBlogsAsync();
        Task<ResponseEntity<GetBlogDTO>> GetBlogByIdAsync(Guid id);
        Task<ResponseEntity<GetBlogDTO>> InsertBlogAsync(InsertBlogDTO blogDTO);
        Task<ResponseEntity<GetBlogDTO>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO);
        Task<ResponseEntity<IEnumerable<GetBlogDTO>>> DeleteBlogByIdAsync(Guid id);
        Task<ResponseEntity<IEnumerable<GetTopBlogDTO>>> GetTopBlogs();
    }
}
