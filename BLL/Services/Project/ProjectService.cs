using AutoMapper;
using BLL.DTOs.ProjectDTO;
using BLL.DTOs.Response.ResponseEntity;
using DAL.WrapperRepository.Interface;
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
            await _wrapperRepository.ProjectRepository.DeleteEntityByIdAsync(id);
            await _wrapperRepository.Save();
            return new ResponseEntity(HttpStatusCode.NoContent, null);
        }

        public Task<ResponseEntity<IEnumerable<GetProjectDTO>>> GetAllProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseEntity<GetProjectDTO>> GetProjectByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /* public async Task<ResponseEntity<IEnumerable<GetProjectDTO>>> GetAllProjectsAsync()
         {
             var projects = await _wrapperRepository.ProjectRepository.GetAllInformationAsync(
                 include:
                 (project) =>
                 project
                 .Include(paragraphs => paragraphs.Paragraphs)
                 .Include(technology => technology.ProjectTechnologies)
                 .Include(customer => customer.Customer)
                 .Include(country => country.Country)
                 .Include(rating => rating.Ratings)
                 .Include(pictures => pictures.Pictures));

             var projectTechnologies = _wrapperRepository.ProjectTechnologyRepository.GetAllTechnologiesAsync(projectDto.Id);

             projectDto.TechnologyDTOs =
                 _mapper.Map<IQueryable<Technology>>,< List < GetTechnologyDTO >> (projectTechnologies);

             var projectsDto = _mapper.Map<ResponseEntity<IEnumerable<DAL.Entities.Project>>, ResponseEntity<IEnumerable<GetProjectDTO>>>(projects);

             foreach (var projectDto in projectsDto.Result!)
             {
                 var ratings = await _wrapperRepository.RatingRepository.GetAllInformationAsync(predicate: rating => rating.ProjectId == projectDto.Id);


                 foreach (var rating in ratings.Result!)
                 {
                     projectDto.Mark += rating.Mark;
                 }
                 projectDto.RatingCount = ratings.Result.Count();
                 projectDto.Mark = projectDto.Mark / projectDto.RatingCount;
             }



             return projectsDto;
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

             var projectDto = _mapper.Map<ResponseEntity<GetProjectDTO>>(project);

             var ratings = await _wrapperRepository.RatingRepository.GetAllInformationAsync(predicate: rating => rating.ProjectId == projectDto.Result.Id);


             foreach (var rating in ratings.Result!)
             {
                 projectDto.Result.Mark += rating.Mark;
             }
             projectDto.Result.RatingCount = ratings.Result.Count();
             projectDto.Result.Mark = projectDto.Result.Mark / projectDto.Result.RatingCount;

             return projectDto;
         }*/

        public Task<ResponseEntity<GetProjectDTO>> InsertProjectAsync(InsertProjectDTO projectDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseEntity<GetProjectDTO>> UpdateProjectAsync(UpdateProjectDTO updateProjectDTO)
        {
            throw new NotImplementedException();
        }

        Task<ResponseEntity<IEnumerable<GetProjectDTO>>> IProjectService.DeleteProjectByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
