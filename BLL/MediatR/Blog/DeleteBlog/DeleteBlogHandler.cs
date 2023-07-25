using BLL.DTOs.BlogDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Services.Blog;
using MediatR;

namespace BLL.MediatR.Blog.DeleteBlog
{
    public class DeleteBlogHandler : IRequestHandler<DeleteBlogCommand, ResponseEntity>
    {
        private readonly IBlogService _blogService;
        public DeleteBlogHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ResponseEntity> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await _blogService.DeleteBlogByIdAsync(request.Id);
        }
    }
}
