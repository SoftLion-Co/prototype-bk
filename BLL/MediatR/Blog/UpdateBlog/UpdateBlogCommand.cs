using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.UpdateBlog
{
    public record UpdateBlogCommand(UpdateBlogDTO UpdateBlogDTO) : IRequest<ResponseEntity<GetBlogDTO>>;
}
