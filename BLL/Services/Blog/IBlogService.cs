using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response;
using Microsoft.AspNetCore.Hosting;

namespace BLL.Services.Blog
{
    public interface IBlogService
    {
        Task<ResponseEntity<IEnumerable<GetBlogDTO>>> GetAllBlogsAsync();
        Task<ResponseEntity<GetBlogDTO>> GetBlogByIdAsync(Guid id);
        Task<ResponseEntity<GetBlogDTO>> InsertBlogAsync(InsertBlogDTO blogDTO, IWebHostEnvironment _appEnvironment);
        Task<ResponseEntity<GetBlogDTO>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO, IWebHostEnvironment _appEnvironment);
        Task<ResponseEntity> DeleteBlogByIdAsync(Guid id);
        Task<ResponseEntity<IEnumerable<GetTopBlogDTO>>> GetTopBlogsAsync();
        Task<ResponseEntity<GetBlogDTO>> AddViewersByIdAsync(Guid id);
    }
}
