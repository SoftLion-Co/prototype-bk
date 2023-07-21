using AutoMapper;
using BLL.DTOs.BlogDTO;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
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

        public async Task<ResponseEntity<IEnumerable<GetBlogDTO>>> DeleteBlogByIdAsync(Guid id)
        {
            var blog = await _wrapperRepository.BlogRepository.DeleteEntityByIdAsync(id);
            var blogDTOs = _mapper.Map<ResponseEntity<IEnumerable<GetBlogDTO>>>(blog);
            await _wrapperRepository.Save();
            return blogDTOs;
        }

        public async Task<ResponseEntity<IEnumerable<GetBlogDTO>>> GetAllBlogsAsync()
        {
            var blogs = await _wrapperRepository.BlogRepository.GetAllInformationAsync(
                include: 
                (blog) => 
                blog.Include(author => author.Author).
                Include(paragraphs => paragraphs.Paragraphs).
                Include(svg => svg.SVG).
                Include(pictures => pictures.Pictures));
            
            var blogsDto = _mapper.Map<ResponseEntity<IEnumerable<DAL.Entities.Blog>>, ResponseEntity<IEnumerable<GetBlogDTO>>>(blogs);
            return blogsDto;
        }

        public async Task<ResponseEntity<GetBlogDTO>> GetBlogByIdAsync(Guid id)
        {
            var blog = await _wrapperRepository.BlogRepository.GetEntityByIdAsync(id, 
                include:(blog => 
                blog.Include(b => b.Pictures)
                .Include(b => b.Paragraphs)
                .Include(b => b.SVG)));
            return _mapper.Map<ResponseEntity<GetBlogDTO>>(blog);
        }

        public async Task<ResponseEntity<IEnumerable<GetTopBlogDTO>>> GetTopBlogs()
        {
            var blogs = await _wrapperRepository.BlogRepository
                .GetAllInformationQueryableAsync(
                selector: blog => new DAL.Entities.Blog{ Id = blog.Id, Title = blog.Title, Description = blog.Description, SVG = blog.SVG },
                include: blog => blog.Include(b => b.SVG));
            var response = await blogs.Result.ProjectTo<GetTopBlogDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetTopBlogDTO>> { Result = response };
        }

        public async Task<ResponseEntity<GetBlogDTO>> InsertBlogAsync(InsertBlogDTO blogDTO)
        {
            var blog = _mapper.Map<InsertBlogDTO, DAL.Entities.Blog>(blogDTO);
            var author = await _wrapperRepository.AuthorRepository.FindByIdAsync(blog.AuthorId);
            if (author is null)
                throw new ArgumentNullException("There is no existing author in the database");
            blog.Author = author;
            foreach (var paragraph in blog.Paragraphs)
            {
                paragraph.BlogId = blog.Id;
                await _wrapperRepository.ParagraphRepository.InsertEntityAsync(paragraph);
            }
            foreach (var picture in blog.Pictures)
            {
                picture.BlogId = blog.Id;
                await _wrapperRepository.PictureRepository.InsertEntityAsync(picture);
            }
            blog.SVG.BlogId = blog.Id;
            await _wrapperRepository.SVGRepository.InsertEntityAsync(blog.SVG);
            var response = await _wrapperRepository.BlogRepository.InsertEntityAsync(blog);
            await _wrapperRepository.Save();
            return _mapper.Map<ResponseEntity<GetBlogDTO>>(response);
        }

        public async Task<ResponseEntity<GetBlogDTO>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO)
        {
            var blog = _mapper.Map<UpdateBlogDTO, DAL.Entities.Blog>(updateBlogDTO);
            var author = await _wrapperRepository.AuthorRepository.FindByIdAsync(blog.AuthorId);
            if (author is null)
                throw new ArgumentNullException("There is no existing author in the database");
            blog.Author = author;
            foreach (var paragraph in blog.Paragraphs)
            {
                await _wrapperRepository.ParagraphRepository.Attach(paragraph);
            }
            foreach (var picture in blog.Pictures)
            {
                await _wrapperRepository.PictureRepository.Attach(picture);
            }
            await _wrapperRepository.SVGRepository.Attach(blog.SVG);
            var response = await _wrapperRepository.BlogRepository.UploadEntityAsync(blog);
            await _wrapperRepository.Save();
            return _mapper.Map<ResponseEntity<GetBlogDTO>>(response);
        }
    }
}
