using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Services.Blog;
using MediatR;

namespace BLL.MediatR.Blog.UpdateBlog
{
    public class UpdateBlogHandler : IRequestHandler<UpdateBlogCommand, ResponseEntity<GetBlogDTO>>
    {
        private readonly IBlogService _blogService;

        public UpdateBlogHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ResponseEntity<GetBlogDTO>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            return await _blogService.UpdateBlogAsync(request.UpdateBlogDTO);
        }
    }
}
