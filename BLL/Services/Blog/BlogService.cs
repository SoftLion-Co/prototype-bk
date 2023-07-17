using AutoMapper;
using BLL.DTOs.AuthorDTO;
using BLL.DTOs.BlogDTO;
using BLL.Services.Blog;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public BlogService(IMapper mapper, IWrapperRepository repository)
        {
            _mapper = mapper;
            _wrapperRepository = repository;
        }

        public Task<ResponseEntity<IEnumerable<GetBlogDTO>>> DeleteBlogByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseEntity<IEnumerable<GetBlogDTO>>> GetAllBlogsAsync()
        {
            var blogs = await _wrapperRepository.BlogRepository.GetAllInformationAsync();
            return _mapper.Map<ResponseEntity<IEnumerable<DAL.Entities.Blog>>, ResponseEntity<IEnumerable<GetBlogDTO>>>(blogs);
        }

        public Task<ResponseEntity<GetBlogDTO>> GetBlogByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseEntity<GetBlogDTO>> InsertBlogAsync(InsertBlogDTO blogDTO)
        {
            var blog = _mapper.Map<InsertBlogDTO, DAL.Entities.Blog>(blogDTO);
            blog.Id = Guid.NewGuid();
            foreach (var paragraph in blog.Paragraphs)
            {
                paragraph.BlogId = blog.Id;
                await _wrapperRepository.ParagraphRepository.InsertEntityAsync(paragraph);
            }
            var response = await _wrapperRepository.BlogRepository.InsertEntityAsync(blog);
            await _wrapperRepository.Save();
            return _mapper.Map<ResponseEntity<GetBlogDTO>>(response);
        }

        public Task<ResponseEntity<GetBlogDTO>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO)
        {
            throw new NotImplementedException();
        }
    }
}
