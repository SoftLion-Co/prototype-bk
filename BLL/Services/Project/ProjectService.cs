using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.ProjectDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using BLL.DTOs.TechnologyDTO;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;
using BLL.DTOs.BlogDTO;
using DAL.Entities;
using BLL.DTOs.CountryDTO;

namespace BLL.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper, IWrapperRepository repository)
        {
            _mapper = mapper;
            _wrapperRepository = repository;
        }

        public async Task<ResponseEntity> DeleteProjectByIdAsync(Guid id)
        {
            var entity = await _wrapperRepository.ProjectRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.Project>();
            await _wrapperRepository.ProjectRepository.DeleteEntityByIdAsync(entity);
            await _wrapperRepository.Save();

            return new ResponseEntity(HttpStatusCode.NoContent);
        }
        public async Task<ResponseEntity<GetProjectDTO>> GetProjectByIdAsync(Guid id)
        {
            var project = await _wrapperRepository.ProjectRepository.GetEntityByIdAsync(id,
                 include: (project =>
                 project
                 .Include(paragraphs => paragraphs.Paragraphs)
                 .Include(technology => technology.ProjectORBlogTechnologies)
                 .Include(country => country.Country)
                 .Include(pictures => pictures.Pictures)));

            var technologies = await _wrapperRepository.ProjectORBlogTechnologyRepository.GetAllTechnologiesByIdAsync(project, null);
            if (technologies == null) { throw NotFoundException.Default<DAL.Entities.Technology>(); }
            var projectDto = _mapper.Map<GetProjectDTO>(project);
            projectDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>, List<GetTechnologyDTO>>(technologies);

            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.OK, projectDto);
        }

        public async Task<ResponseEntity<IEnumerable<GetProjectDTO>>> GetAllProjectsAsync()
        {
            var projects = await _wrapperRepository.ProjectRepository.GetAllAsync(
                 include: (project =>
                 project
                 .Include(paragraphs => paragraphs.Paragraphs)
                 .Include(technology => technology.ProjectORBlogTechnologies)
                 .Include(country => country.Country)
                 .Include(pictures => pictures.Pictures)));

            var projectsDTO = _mapper.Map<IEnumerable<GetProjectDTO>>(projects);

            foreach (var projectDto in projectsDTO)
            {
                var technologies = await _wrapperRepository.ProjectORBlogTechnologyRepository.GetAllTechnologiesByIdAsync(_mapper.Map<DAL.Entities.Project>(projectDto), null);
                if(technologies == null || technologies.Count()==0) { throw NotFoundException.Default<DAL.Entities.Technology>(); }
                projectDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>,List<GetTechnologyDTO>>(technologies);
                
            }
            var paragraphs = await _wrapperRepository.ParagraphRepository.GetAllAsync();
            foreach (var paragraph in paragraphs)
            {
                Console.WriteLine(paragraph); 
            }

            return new ResponseEntity<IEnumerable<GetProjectDTO>>(HttpStatusCode.OK,projectsDTO);
        }

        public async Task<ResponseEntity<IEnumerable<GetTopProjectDTO>>> GetTopProjectsAsync()
        {
            var projects = await _wrapperRepository.ProjectRepository.GetAllAsync(
                 include: (project =>
                 project
                 .Include(paragraphs => paragraphs.Paragraphs)
                 .Include(technology => technology.ProjectORBlogTechnologies)
                 .Include(country => country.Country)
                 .Include(pictures => pictures.Pictures)));

            var projectsDTO = _mapper.Map<IEnumerable<GetTopProjectDTO>>(projects);

            foreach (var projectDto in projectsDTO)
            {
                var technologies = await _wrapperRepository.ProjectORBlogTechnologyRepository.GetAllTechnologiesByIdAsync(_mapper.Map<DAL.Entities.Project>(projectDto), null);
                if (technologies == null || technologies.Count() == 0) { throw NotFoundException.Default<DAL.Entities.Technology>(); }
                projectDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>, List<GetTechnologyDTO>>(technologies);

            }
            var paragraphs = await _wrapperRepository.ParagraphRepository.GetAllAsync();
            foreach (var paragraph in paragraphs)
            {
                Console.WriteLine(paragraph);
            }

            return new ResponseEntity<IEnumerable<GetTopProjectDTO>>(HttpStatusCode.OK, projectsDTO);
        }
        public async Task<ResponseEntity<GetProjectDTO>> InsertProjectAsync(InsertProjectDTO projectDTO)
        {
            var project = _mapper.Map<InsertProjectDTO, DAL.Entities.Project>(projectDTO);
            var country = await _wrapperRepository.CountryRepository.FindByIdAsync(project.Country.Id);

            if (country is null)
            {
                country = await _wrapperRepository.CountryRepository.InsertEntityAsync(_mapper.Map<InsertCountryDTO,DAL.Entities.Country>(projectDTO.Country));
            }
            project.Country = country;
            project.CountryId = country.Id;

            foreach (var paragraph in project.Paragraphs)
            {
                paragraph.ProjectId = project.Id;
                paragraph.BlogId = null;
                await _wrapperRepository.ParagraphRepository.InsertEntityAsync(paragraph);
            }

            foreach (var picture in project.Pictures)
            {
                picture.ProjectId = project.Id;
                picture.BlogId = null;
                await _wrapperRepository.PictureRepository.InsertEntityAsync(picture);
            }

            foreach (var technologyDTO in _mapper.ProjectTo<DAL.Entities.Technology>(projectDTO.Technologies.AsQueryable()))
            {
                var technology = await _wrapperRepository.TechnologyRepository.FindByIdAsync(technologyDTO.Id);
                if(technology is null)
                {
                    technology = await _wrapperRepository.TechnologyRepository.InsertEntityAsync(technologyDTO);
                }
                await _wrapperRepository.ProjectORBlogTechnologyRepository.InsertEntityAsync(project, technology);
            }
            var response = await _wrapperRepository.ProjectRepository.InsertEntityAsync(project);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.Created, _mapper.Map<GetProjectDTO>(response));
        }

        public async Task<ResponseEntity<GetProjectDTO>> UpdateProjectAsync(UpdateProjectDTO updateProjectDTO)
        {
            var project = _mapper.Map<UpdateProjectDTO, DAL.Entities.Project>(updateProjectDTO);
            var country = await _wrapperRepository.CountryRepository.FindByIdAsync(project.Country.Id);

            if (country is null)
            {
                country = await _wrapperRepository.CountryRepository.UploadEntityAsync(_mapper.Map<UpdateCountryDTO, DAL.Entities.Country>(updateProjectDTO.Country));
            }
            project.Country = country;
            project.CountryId = country.Id;

            foreach (var paragraph in project.Paragraphs)
            {
                paragraph.ProjectId = project.Id;
                paragraph.BlogId = null;
                await _wrapperRepository.ParagraphRepository.UploadEntityAsync(paragraph);
            }

            foreach (var picture in project.Pictures)
            {
                picture.ProjectId = project.Id;
                picture.BlogId = null;
                await _wrapperRepository.PictureRepository.UploadEntityAsync(picture);
            }
            var technologies = await _wrapperRepository.ProjectORBlogTechnologyRepository.GetAllTechnologiesByIdAsync(project, null);

            foreach (var technologyDTO in _mapper.ProjectTo<DAL.Entities.Technology>(updateProjectDTO.Technologies.AsQueryable()))
            {
                var existingTechnology = technologies.FirstOrDefault(t => t.Name == technologyDTO.Name);
                var findtechnology = _wrapperRepository.TechnologyRepository.GetAllAsync();
                var existinOfAllTechnology = technologies.FirstOrDefault(t => t.Name == technologyDTO.Name);
                if (existinOfAllTechnology is null)
                {
                    await _wrapperRepository.TechnologyRepository.InsertEntityAsync(technologyDTO);
                }
                if (existingTechnology is null)
                {
                    await _wrapperRepository.ProjectORBlogTechnologyRepository.InsertEntityAsync(project, technologyDTO);
                }

            }
            foreach (var technology in technologies)
            {
                if (!updateProjectDTO.Technologies.Any(t => t.Id == technology.Id))
                {
                    await _wrapperRepository.ProjectORBlogTechnologyRepository.DeleteEntityByIdAsync(project, null, technology.Id);
                }
            }

                var response = await _wrapperRepository.ProjectRepository.UploadEntityAsync(project);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.Created, _mapper.Map<GetProjectDTO>(response));
        }
    }
}
