using BLL.DTOs.BlogDTO;
using BLL.Services.Blog;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.GetTopBlogs
{
    public class GetAllTopBlogsHandler : IRequestHandler<GetAllTopBlogsQuery, ResponseEntity<IEnumerable<GetTopBlogDTO>>>
    {
        private readonly IBlogService _blogService;

        public GetAllTopBlogsHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ResponseEntity<IEnumerable<GetTopBlogDTO>>> Handle(GetAllTopBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _blogService.GetTopBlogs();
        }
    }
}
