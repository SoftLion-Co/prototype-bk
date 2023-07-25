using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.DeleteBlog
{
    public record DeleteBlogCommand(Guid Id) : IRequest<ResponseEntity>;
}
