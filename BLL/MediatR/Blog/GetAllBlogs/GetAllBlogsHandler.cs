﻿using BLL.DTOs.BlogDTO;
using BLL.Services.Blog;
using DAL.Entities.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Blog.GetAllBlogs
{
    public class GetAllBlogsHandler : IRequestHandler<GetAllBlogsQuery, ResponseEntity<IEnumerable<GetBlogDTO>>>
    {
        private readonly IBlogService _blogService;

        public GetAllBlogsHandler(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ResponseEntity<IEnumerable<GetBlogDTO>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _blogService.GetAllBlogsAsync();
        }
    }
}