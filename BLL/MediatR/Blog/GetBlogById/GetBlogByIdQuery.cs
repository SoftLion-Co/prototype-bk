using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.GetBlogById
{
    public record GetBlogByIdQuery(Guid Id) : IRequest<ResponseEntity<GetBlogDTO>>;
}
