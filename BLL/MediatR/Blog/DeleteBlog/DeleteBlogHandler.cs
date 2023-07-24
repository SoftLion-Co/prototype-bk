using BLL.DTOs.BlogDTO;
using BLL.Services.Blog;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.DeleteBlog
{
    public class DeleteBlogHandler : IRequestHandler<DeleteBlogCommand, ResponseEntity<IEnumerable<GetBlogDTO>>>
    {
        private readonly IBlogService _blogService;
        public DeleteBlogHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ResponseEntity<IEnumerable<GetBlogDTO>>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await _blogService.DeleteBlogByIdAsync(request.Id);
        }
    }
}
