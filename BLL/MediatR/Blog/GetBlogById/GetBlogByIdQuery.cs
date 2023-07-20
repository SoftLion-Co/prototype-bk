using BLL.DTOs.BlogDTO;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.GetBlogById
{
    public record GetBlogByIdQuery(Guid Id) : IRequest<ResponseEntity<GetBlogDTO>>;
}
