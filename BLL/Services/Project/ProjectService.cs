using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.ProjectDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response.ResponseEntity;
using BLL.DTOs.TechnologyDTO;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

        public async Task<ResponseEntity<GetProjectDTO>> InsertProjectAsync(InsertProjectDTO projectDTO)
        {
            var project = _mapper.Map<InsertProjectDTO, DAL.Entities.Project>(projectDTO);
            var country = await _wrapperRepository.CountryRepository.FindByIdAsync(project.CountryId);

            if (country is null)
            {
                throw NotFoundException.Default<GetBlogDTO>();
            }
            project.Country = country;

            foreach (var paragraph in project.Paragraphs)
            {
                paragraph.ProjectId = project.Id;
                await _wrapperRepository.ParagraphRepository.InsertEntityAsync(paragraph);
            }

            foreach (var picture in project.Pictures)
            {
                picture.ProjectId = project.Id;
                await _wrapperRepository.PictureRepository.InsertEntityAsync(picture);
            }

            foreach (var technology in _mapper.ProjectTo<DAL.Entities.Technology>(projectDTO.TechnologyDTOs.AsQueryable()))
            {
                await _wrapperRepository.ProjectTechnologyRepository.InsertEntityAsync(project, technology);
            }

            var response = await _wrapperRepository.ProjectRepository.InsertEntityAsync(project);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.Created, null, _mapper.Map<GetProjectDTO>(response));
        }

        public async Task<ResponseEntity<GetProjectDTO>> UpdateProjectAsync(UpdateProjectDTO updateProjectDTO)
        {
            var project = _mapper.Map<UpdateProjectDTO, DAL.Entities.Project>(updateProjectDTO);
            var country = await _wrapperRepository.CountryRepository.FindByIdAsync(project.CountryId);

            if (country is null)
            {
                throw NotFoundException.Default<GetBlogDTO>();
            }
            else if(country != project.Country)
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

            var technologies = _mapper.ProjectTo<DAL.Entities.Technology>(updateProjectDTO.TechnologyDTOs.AsQueryable());

            foreach (var technology in technologies)
            {
                if(projectTechnologies.Any(pt => pt.Technology.Id == technology.Id)!)
                {
                    await _wrapperRepository.ProjectTechnologyRepository.InsertEntityAsync(project, technology);
                }
                
               
            }
            foreach (var technology in projectTechnologies)
            {
                if (technologies.Any(pt => pt.Id == technology.TechnologyId)!)
                {
                    await _wrapperRepository.ProjectTechnologyRepository.DeleteEntityByIdAsync(project.Id,technology.TechnologyId);
                }
            }

            var response = await _wrapperRepository.ProjectRepository.UploadEntityAsync(project);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.Created, null, _mapper.Map<GetProjectDTO>(response));

        }

        public Task<ResponseEntity<IEnumerable<GetProjectDTO>>> GetAllProjectsAsync()
        {
            throw new NotImplementedException();
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

            var projectDto = _mapper.Map<GetProjectDTO>(project);

            /*var ratings = await _wrapperRepository.RatingRepository.GetAllInformationAsync(predicate: rating => rating.ProjectId == projectDto.Id);*/

            projectDto.TechnologyDTOs = await technologies.ProjectTo<GetTechnologyDTO>(_mapper.ConfigurationProvider).ToListAsync();

            foreach (var rating in project.Ratings!)
            {
                projectDto.Mark += rating.Mark;
            }
            projectDto.RatingCount = project.Ratings.Count();
            projectDto.Mark = projectDto.Mark / projectDto.RatingCount;
                
            return new ResponseEntity<GetProjectDTO>(HttpStatusCode.OK, null, projectDto);
        }

        public Task<ResponseEntity<IEnumerable<GetTopProjectDTO>>> GetTopProjectsAsync()
        {
            throw new NotImplementedException();
        }

       
    }
}
