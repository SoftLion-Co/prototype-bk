using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Services.Blog;
using MediatR;

namespace BLL.MediatR.Blog.GetBlogById
{
    public class GetBlogByIdHandler : IRequestHandler<GetBlogByIdQuery, ResponseEntity<GetBlogDTO>>
    {
        private readonly IBlogService _blogService;

        public GetBlogByIdHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ResponseEntity<GetBlogDTO>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            return await _blogService.GetBlogByIdAsync(request.Id);
        }
    }
}
