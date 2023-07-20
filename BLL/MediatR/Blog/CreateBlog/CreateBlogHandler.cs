using BLL.DTOs.BlogDTO;
using BLL.Services.Blog;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.CreateBlog
{
    public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, ResponseEntity<GetBlogDTO>>
    {
        private readonly IBlogService _blogService;

        public CreateBlogHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ResponseEntity<GetBlogDTO>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            return await _blogService.InsertBlogAsync(request.InsertBlogDTO);
        }
    }
}
