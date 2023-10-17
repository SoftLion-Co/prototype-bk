using BLL.DTOs.BlogDTO;
using BLL.Services.Blog;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/blog")]

    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// Information about all blogs
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBlogsAsync()
        {
            var response = await _blogService.GetAllBlogsAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about all short blogs
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpGet("get-short-all")]
        public async Task<IActionResult> GetAllTopBlogsAsync()
        {
            var response = await _blogService.GetTopBlogsAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific blog
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogByIdAsync([FromQuery] Guid id)
        {
            var response = await _blogService.GetBlogByIdAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// To create a blog
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpPost]
        public async Task<IActionResult> CreateBlogAsync([FromBody] InsertBlogDTO insertBlogDTO)
        {
            var response = await _blogService.InsertBlogAsync(insertBlogDTO);
            return Ok(response);
        }

        /// <summary>
        /// To update already existing blog
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBlogAsync([FromBody] UpdateBlogDTO updateBlogDTO)
        {
            var response = await _blogService.UpdateBlogAsync(updateBlogDTO);
            return Ok(response);
        }

        /// <summary>
        /// To delete a blog  by id
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogAsync(Guid id)
        {
            var response = await _blogService.DeleteBlogByIdAsync(id);
            return Ok(response);
        }
    }
}
