using BLL.DTOs.BlogDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.UpdateBlog
{
    public record UpdateBlogCommand(UpdateBlogDTO UpdateBlogDTO) : IRequest<ResponseEntity<GetBlogDTO>>;
}
