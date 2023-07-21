using BLL.DTOs.BlogDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.GetTopBlogs
{
    public record GetAllTopBlogsQuery() : IRequest<ResponseEntity<IEnumerable<GetTopBlogDTO>>>;
}
