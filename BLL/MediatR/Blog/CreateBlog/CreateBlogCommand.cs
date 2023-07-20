using BLL.DTOs.BlogDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.CreateBlog
{
    public record CreateBlogCommand(InsertBlogDTO InsertBlogDTO) : IRequest<ResponseEntity<GetBlogDTO>>;
}
