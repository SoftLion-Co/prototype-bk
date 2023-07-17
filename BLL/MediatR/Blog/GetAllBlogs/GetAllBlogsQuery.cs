using BLL.DTOs.BlogDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.GetAllBlogs
{
    public record GetAllBlogsQuery() : IRequest<ResponseEntity<IEnumerable<GetBlogDTO>>>;
}
