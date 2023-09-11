using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Helpers;

namespace BLL.Services.Blog
{
    public interface IBlogService
    {
        Task<ResponseEntity<IEnumerable<GetBlogDTO>>> GetAllBlogsAsync();
        Task<ResponseEntity<GetBlogDTO>> GetBlogByIdAsync(Guid id);
        Task<ResponseEntity<GetBlogDTO>> InsertBlogAsync(InsertBlogDTO blogDTO);
        Task<ResponseEntity<GetBlogDTO>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO);
        Task<ResponseEntity> DeleteBlogByIdAsync(Guid id);
        Task<ResponseEntity<IEnumerable<GetTopBlogDTO>>> GetTopBlogs();
        Task<PagedList<GetTopBlogDTO>> GetBlogsPaginationAsync(ItemParameters itemParameters);
    }
}
