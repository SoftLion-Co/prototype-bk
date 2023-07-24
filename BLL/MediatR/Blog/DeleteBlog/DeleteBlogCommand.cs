using BLL.DTOs.BlogDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.DeleteBlog
{
    public record DeleteBlogCommand(Guid Id) : IRequest<ResponseEntity<IEnumerable<GetBlogDTO>>>;
}
