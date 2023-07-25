using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.GetAllBlogs
{
    public record GetAllBlogsQuery() : IRequest<ResponseEntity<IEnumerable<GetBlogDTO>>>;
}
