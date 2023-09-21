using AutoMapper;
using BLL.DTOs.BlogDTO;
using BLL.DTOs.Exceptions;
using AutoMapper.QueryableExtensions;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;
using BLL.DTOs.Response;

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

        public async Task<ResponseEntity> DeleteBlogByIdAsync(Guid id)
        {
            var entity = await _wrapperRepository.BlogRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.Blog>();
            await _wrapperRepository.BlogRepository.DeleteEntityByIdAsync(entity);
            await _wrapperRepository.Save();

            return new ResponseEntity(HttpStatusCode.NoContent);
        }

        public async Task<ResponseEntity<IEnumerable<GetBlogDTO>>> GetAllBlogsAsync()
        {
            var blogs = await _wrapperRepository.BlogRepository.GetAllAsync(
                include: 
                (blog) => 
                blog.Include(author => author.Author).
                Include(paragraphs => paragraphs.Paragraphs).
                Include(svg => svg.SVG).
                Include(pictures => pictures.Pictures));

            return new ResponseEntity<IEnumerable<GetBlogDTO>>(HttpStatusCode.OK,  _mapper.Map<IEnumerable<GetBlogDTO>>(blogs));
        }

        public async Task<ResponseEntity<GetBlogDTO>> GetBlogByIdAsync(Guid id)
        {
            var blog = await _wrapperRepository.BlogRepository.GetEntityByIdAsync(id, 
                include:(blog => 
                blog.Include(b => b.Pictures)
                .Include(b => b.Paragraphs)
                .Include(b => b.SVG)));
            
            if (blog is null)
            {
                throw NotFoundException.Default<DAL.Entities.Blog>();
            }
            
            return _mapper.Map<ResponseEntity<GetBlogDTO>>(blog);
        }

        public async Task<ResponseEntity<GetBlogDTO>> InsertBlogAsync(InsertBlogDTO blogDTO)
        {
            var blog = _mapper.Map<InsertBlogDTO, DAL.Entities.Blog>(blogDTO);
            var author = await _wrapperRepository.AuthorRepository.FindByIdAsync(blog.AuthorId);

            if (author is null)
            {
                throw NotFoundException.Default<GetBlogDTO>();
            }
            
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

            return new ResponseEntity<GetBlogDTO>(HttpStatusCode.Created,  _mapper.Map<GetBlogDTO>(response));
        }

        public async Task<ResponseEntity<IEnumerable<GetTopBlogDTO>>> GetTopBlogs()
        {
            var blogs = await _wrapperRepository.BlogRepository
                .GetAllInformationAsync(
                selector: blog => new DAL.Entities.Blog { Id = blog.Id, Title = blog.Title, Description = blog.Description, SVG = blog.SVG },
                include: blog => blog.Include(b => b.SVG));

            var result = _mapper.Map<IEnumerable<GetTopBlogDTO>>(blogs);
            
            return new ResponseEntity<IEnumerable<GetTopBlogDTO>>(HttpStatusCode.Created,  result);
        }


        public async Task<ResponseEntity<GetBlogDTO>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO)
        {
            var blog = _mapper.Map<UpdateBlogDTO, DAL.Entities.Blog>(updateBlogDTO);
            var author = await _wrapperRepository.AuthorRepository.FindByIdAsync(blog.AuthorId);

            if (author is null)
            {
                throw NotFoundException.Default<GetBlogDTO>();
            }
            blog.Author = author;

            foreach (var paragraph in blog.Paragraphs)
            {
                await _wrapperRepository.ParagraphRepository.UploadEntityAsync(paragraph);
            }

            foreach (var picture in blog.Pictures)
            {
                await _wrapperRepository.PictureRepository.UploadEntityAsync(picture);
            }

            await _wrapperRepository.SVGRepository.UploadEntityAsync(blog.SVG);
            var response = await _wrapperRepository.BlogRepository.UploadEntityAsync(blog);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetBlogDTO>(HttpStatusCode.OK,  _mapper.Map<GetBlogDTO>(response));
        }

        public async Task<PagedList<GetTopBlogDTO>> GetBlogsPaginationAsync(ItemParameters itemParameters)
        {
            var blogs = await _wrapperRepository.BlogRepository
                .GetAllInformationAsync(
                selector: blog => new DAL.Entities.Blog { Id = blog.Id, Title = blog.Title, Description = blog.Description, SVG = blog.SVG },
                include: blog => blog.Include(b => b.SVG));

            var response = await blogs.ProjectTo<GetTopBlogDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return PagedList<GetTopBlogDTO>.ToPagedList(response, itemParameters.PageNumber, itemParameters.PageSize);
        }

    }
}
