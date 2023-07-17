using BLL.DTOs.BlogDTO;
using BLL.MediatR.Blog.GetAllBlogs;
using DAL.Entities.ResponseEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/blog")]
    public class BlogController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ResponseEntity<IEnumerable<GetBlogDTO>>>> GetAllBlogs()
        {
            return Ok(await Mediator.Send(new GetAllBlogsQuery()));
        }
    }
}
