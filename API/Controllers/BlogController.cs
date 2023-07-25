﻿using BLL.DTOs.BlogDTO;
using BLL.MediatR.Blog.CreateBlog;
using BLL.MediatR.Blog.DeleteBlog;
using BLL.MediatR.Blog.GetAllBlogs;
using BLL.MediatR.Blog.GetBlogById;
using BLL.MediatR.Blog.UpdateBlog;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/blogs")]

    public class BlogController : BaseApiController
    {
        /// <summary>
        /// Information about all blogs
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            return Ok(await Mediator.Send(new GetAllBlogsQuery()));
        }
        /// <summary>
        /// Information about a specific blog
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogByIdAsync(Guid id)
        {
            return Ok(await Mediator.Send(new GetBlogByIdQuery(id)));
        }
        /// <summary>
        /// To create a blog
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] InsertBlogDTO insertBlogDTO)
        {
            return Ok(await Mediator.Send(new CreateBlogCommand(insertBlogDTO)));
        }
        /// <summary>
        /// To update already existing blog
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogDTO updateBlogDTO)
        {
            return Ok(await Mediator.Send(new UpdateBlogCommand(updateBlogDTO)));
        }
        /// <summary>
        /// To delete a blog  by id
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteBlogCommand(id)));
        }
    }
}
