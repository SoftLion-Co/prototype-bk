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
                 .Include(technology => technology.ProjectTechnologies)
                 .Include(customer => customer.Customer)
                 .Include(country => country.Country)
                 .Include(rating => rating.Ratings)
                 .Include(pictures => pictures.Pictures)));

            var technologies = await _wrapperRepository.ProjectTechnologyRepository.GetAllTechnologiesByIdAsync(id);
            if (technologies == null) { throw NotFoundException.Default<DAL.Entities.Technology>(); }
            var projectDto = _mapper.Map<GetProjectDTO>(project);
            projectDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>, List<GetTechnologyDTO>>(technologies);

            var ratings = await _wrapperRepository.RatingRepository.GetAllAsync(predicate: rating => rating.ProjectId == projectDto.Id);


            foreach (var rating in ratings!)
            {
                projectDto.Mark += rating.Mark;
            }
            projectDto.Mark = projectDto.Mark / projectDto.RatingCount;

            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.OK, projectDto);
        }

        public async Task<ResponseEntity<IEnumerable<GetProjectDTO>>> GetAllProjectsAsync()
        {
            var projects = await _wrapperRepository.ProjectRepository.GetAllAsync(
                 include: (project =>
                 project
                 .Include(paragraphs => paragraphs.Paragraphs)
                 .Include(technology => technology.ProjectTechnologies)
                 .Include(customer => customer.Customer)
                 .Include(country => country.Country)
                 .Include(rating => rating.Ratings)
                 .Include(pictures => pictures.Pictures)));

            var projectsDTO = _mapper.Map<IEnumerable<GetProjectDTO>>(projects);

            foreach (var projectDto in projectsDTO)
            {
                var technologies = await _wrapperRepository.ProjectTechnologyRepository.GetAllTechnologiesByIdAsync(projectDto.Id);
                if(technologies == null || technologies.Count()==0) { throw NotFoundException.Default<DAL.Entities.Technology>(); }
                projectDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>,List<GetTechnologyDTO>>(technologies);

                var ratings = await _wrapperRepository.RatingRepository.GetAllAsync(predicate: rating => rating.ProjectId == projectDto.Id);

                if (ratings.Count() != 0)
                {
                    foreach (var rating in ratings!)
                    {
                        projectDto.Mark += rating.Mark;
                    }
                    projectDto.Mark = projectDto.Mark / projectDto.RatingCount;
                }
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
            var fakeData = new List<GetTopProjectDTO>();
            return new ResponseEntity<IEnumerable<GetTopProjectDTO>>(HttpStatusCode.IMUsed,fakeData);
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

            foreach (var technology in _mapper.ProjectTo<DAL.Entities.Technology>(projectDTO.Technologies.AsQueryable()))
            {
                await _wrapperRepository.ProjectTechnologyRepository.InsertEntityAsync(project, technology);

            }

            var response = await _wrapperRepository.ProjectRepository.InsertEntityAsync(project);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.Created, _mapper.Map<GetProjectDTO>(response));
        }

        public async Task<ResponseEntity<GetProjectDTO>> UpdateProjectAsync(UpdateProjectDTO updateProjectDTO)
        {
            var project = _mapper.Map<UpdateProjectDTO, DAL.Entities.Project>(updateProjectDTO);
            var country = await _wrapperRepository.CountryRepository.FindByIdAsync(project.CountryId);

            if (country is null)
            {
                throw NotFoundException.Default<GetBlogDTO>();
            }
            else if (country != project.Country)
            {
                project.Country = country;
            }

            foreach (var paragraph in project.Paragraphs)
            {
                if (paragraph.ProjectId != project.Id)
                {
                    paragraph.ProjectId = project.Id;
                    await _wrapperRepository.ParagraphRepository.UploadEntityAsync(paragraph);
                }
            }

            foreach (var picture in project.Pictures)
            {
                if (picture.ProjectId != project.Id)
                {
                    picture.ProjectId = project.Id;
                    await _wrapperRepository.PictureRepository.UploadEntityAsync(picture);
                }
            }
            var projectTechnologies = await _wrapperRepository.ProjectTechnologyRepository.GetProjectTechnologiesByIdAsync(project.Id,
                include:
                (projectTech) =>
                projectTech.
                Include(tech => tech.Technology).
                Include(project => project.Project));

            var technologies = _mapper.ProjectTo<DAL.Entities.Technology>(updateProjectDTO.Technologies.AsQueryable());

            foreach (var technology in technologies)
            {
                if (projectTechnologies.Any(pt => pt.Technology.Id == technology.Id)!)
                {
                    await _wrapperRepository.ProjectTechnologyRepository.InsertEntityAsync(project, technology);
                }


            }
            foreach (var technology in projectTechnologies)
            {
                if (technologies.Any(pt => pt.Id == technology.TechnologyId)!)
                {
                    await _wrapperRepository.ProjectTechnologyRepository.DeleteEntityByIdAsync(project.Id, technology.TechnologyId);
                }
            }

            var response = await _wrapperRepository.ProjectRepository.UploadEntityAsync(project);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.Created,_mapper.Map<GetProjectDTO>(response));

        }

        

        



    }
}
