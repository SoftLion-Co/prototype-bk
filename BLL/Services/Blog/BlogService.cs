﻿using AutoMapper;
using BLL.DTOs.BlogDTO;
using BLL.DTOs.Exceptions;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;
using BLL.DTOs.Response;
using BLL.DTOs.TechnologyDTO;
using Microsoft.AspNetCore.Hosting;

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
        public async Task<ResponseEntity<GetBlogDTO>> AddViewersByIdAsync(Guid id)
        {
            var blog = await _wrapperRepository.BlogRepository.GetEntityByIdAsync(id,
               include: (blog =>
               blog.Include(b => b.Pictures)
               .Include(b => b.Paragraphs)
               .Include(b => b.ProjectORBlogTechnologies)
               .Include(b => b.Ratings)
               .Include(b => b.SVG)));

            blog.Viewers++;
            await _wrapperRepository.BlogRepository.UploadEntityAsync(blog);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetBlogDTO>(HttpStatusCode.Created, _mapper.Map<GetBlogDTO>(blog));
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
                Include(svg => svg.SVG)
                .Include(rat => rat.Ratings)
                .Include(technology => technology.ProjectORBlogTechnologies)
                .Include(pictures => pictures.Pictures));

            var blogsDTO = _mapper.Map<IEnumerable<GetBlogDTO>>(blogs);
            foreach (var blogDto in blogsDTO)
            {
                var technologies = await _wrapperRepository.ProjectORBlogTechnologyRepository.GetAllTechnologiesByIdAsync(null, _mapper.Map<DAL.Entities.Blog>(blogDto));
                if (technologies == null || technologies.Count() == 0) { throw NotFoundException.Default<DAL.Entities.Technology>(); }
                blogDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>, List<GetTechnologyDTO>>(technologies);
            }

            return new ResponseEntity<IEnumerable<GetBlogDTO>>(HttpStatusCode.OK,  _mapper.Map<IEnumerable<GetBlogDTO>>(blogs));
        }

        public async Task<ResponseEntity<GetBlogDTO>> GetBlogByIdAsync(Guid id)
        {
            var blog = await _wrapperRepository.BlogRepository.GetEntityByIdAsync(id, 
                include:(blog => 
                blog.Include(b => b.Pictures)
                .Include(b => b.Paragraphs)
                .Include(b => b.ProjectORBlogTechnologies)
                .Include(b=>b.Ratings)
                .Include(b => b.SVG)));
            
            if (blog is null)
            {
                throw NotFoundException.Default<DAL.Entities.Blog>();
            }

            return new ResponseEntity<GetBlogDTO>(HttpStatusCode.Created, _mapper.Map<GetBlogDTO>(blog));
        }

        public async Task<ResponseEntity<GetBlogDTO>> InsertBlogAsync(InsertBlogDTO blogDTO, IWebHostEnvironment _appEnvironment)
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
                paragraph.ProjectId = null;
                await _wrapperRepository.ParagraphRepository.InsertEntityAsync(paragraph);
            }

            foreach (var picture in blog.Pictures)
            {
                string path = "/images/blog/" + blog.Title.Replace(" ", "-").ToLower() + "/" + blogDTO.Pictures.FirstOrDefault(x => x.Position == picture.Position).Url.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await blogDTO.Pictures.FirstOrDefault(x => x.Position == picture.Position).Url.CopyToAsync(fileStream);
                }
                picture.Url = "/../../.." + path;
                picture.BlogId = blog.Id;
                picture.ProjectId = null;
                await _wrapperRepository.PictureRepository.InsertEntityAsync(picture);
            }


            var technologies = await _wrapperRepository.TechnologyRepository.GetAllExistingAsync();

            foreach (var technologyDTO in _mapper.ProjectTo<DAL.Entities.Technology>(blogDTO.Technologies.AsQueryable()))
            {
                var technology = technologies.FirstOrDefault(x => x.Name == technologyDTO.Name);

                if (technology is null)
                {
                    technology = await _wrapperRepository.TechnologyRepository.InsertEntityAsync(technologyDTO);
                    await _wrapperRepository.Save();
                }

                await _wrapperRepository.ProjectORBlogTechnologyRepository.InsertEntityAsync(blog, technology);
            }

            blog.SVG.BlogId = blog.Id;
            await _wrapperRepository.SVGRepository.InsertEntityAsync(blog.SVG);
            var response = await _wrapperRepository.BlogRepository.InsertEntityAsync(blog);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetBlogDTO>(HttpStatusCode.Created,  _mapper.Map<GetBlogDTO>(response));
        }

        public async Task<ResponseEntity<IEnumerable<GetTopBlogDTO>>> GetTopBlogsAsync()
        {
            var blogs = await _wrapperRepository.BlogRepository
                .GetAllAsync(
                 selector: blog => new DAL.Entities.Blog { Id = blog.Id, Title = blog.Title, Description = blog.Description, SVG = blog.SVG },
                 include: blog => blog.Include(b => b.SVG));

            var blogsDTO = _mapper.Map<IEnumerable<GetTopBlogDTO>>(blogs);

            foreach (var blogDto in blogsDTO)
            {
                var technologies = await _wrapperRepository.ProjectORBlogTechnologyRepository.GetAllTechnologiesByIdAsync(null, _mapper.Map<DAL.Entities.Blog>(blogDto));
                if (technologies == null || technologies.Count() == 0) { throw NotFoundException.Default<DAL.Entities.Technology>(); }
                blogDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>, List<GetTechnologyDTO>>(technologies);
            }
            return new ResponseEntity<IEnumerable<GetTopBlogDTO>>(HttpStatusCode.Created, blogsDTO);
        }


        public async Task<ResponseEntity<GetBlogDTO>> UpdateBlogAsync(UpdateBlogDTO updateBlogDTO, IWebHostEnvironment _appEnvironment)
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

            var technologies = await _wrapperRepository.ProjectORBlogTechnologyRepository.GetAllTechnologiesByIdAsync(null, blog);
            var findtechnology = await _wrapperRepository.TechnologyRepository.GetAllExistingAsync();

            foreach (var technologyDTO in _mapper.ProjectTo<DAL.Entities.Technology>(updateBlogDTO.Technologies.AsQueryable()))
            {
                var existingTechnology = technologies.FirstOrDefault(t => t.Name == technologyDTO.Name);
                var existinOfAllTechnology = findtechnology.FirstOrDefault(t => t.Name == technologyDTO.Name);
                if (existinOfAllTechnology is null)
                {
                    var tech = await _wrapperRepository.TechnologyRepository.InsertEntityAsync(technologyDTO);
                    await _wrapperRepository.ProjectORBlogTechnologyRepository.InsertEntityAsync(blog, tech);
                }
                else if (existingTechnology is null)
                {
                    technologyDTO.Id = existinOfAllTechnology.Id;
                    await _wrapperRepository.ProjectORBlogTechnologyRepository.InsertEntityAsync(blog, technologyDTO);
                }
                else
                {
                    technologyDTO.Id = existingTechnology.Id;
                    await _wrapperRepository.TechnologyRepository.UploadEntityAsync(technologyDTO);
                }

            }
            foreach (var technology in technologies)
            {
                if (!updateBlogDTO.Technologies.Any(t => t.Id == technology.Id))
                {
                    await _wrapperRepository.ProjectORBlogTechnologyRepository.DeleteEntityByIdAsync(null, blog, technology.Id);
                }
            }

            await _wrapperRepository.SVGRepository.UploadEntityAsync(blog.SVG);
            var response = await _wrapperRepository.BlogRepository.UploadEntityAsync(blog);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetBlogDTO>(HttpStatusCode.OK,  _mapper.Map<GetBlogDTO>(response));
        }
    }
}
