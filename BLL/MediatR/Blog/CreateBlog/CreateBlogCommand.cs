using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.CreateBlog
{
    public record CreateBlogCommand(InsertBlogDTO InsertBlogDTO) : IRequest<ResponseEntity<GetBlogDTO>>;
}
