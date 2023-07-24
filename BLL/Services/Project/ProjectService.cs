/*using AutoMapper;
using BLL.DTOs.ProjectDTO;
using BLL.DTOs.TechnologyDTO;
using DAL.Entities;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public async Task<ResponseEntity<IEnumerable<GetProjectDTO>>> DeleteProjectByIdAsync(Guid id)
        {
            var project = await _wrapperRepository.ProjectRepository.DeleteEntityByIdAsync(id);
            var projectDTOs = _mapper.Map<ResponseEntity<IEnumerable<GetProjectDTO>>>(project);
            await _wrapperRepository.Save();

            return projectDTOs;
        }

        public async Task<ResponseEntity<IEnumerable<GetProjectDTO>>> GetAllProjectsAsync()
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

            *//*var projectTechnologies = _wrapperRepository.ProjectTechnologyRepository.GetAllTechnologiesAsync(projectDto.Id);

            projectDto.TechnologyDTOs =
                _mapper.Map<IQueryable<Technology>>,< List < GetTechnologyDTO >> (projectTechnologies);*//*

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
        }

       
        
}
*/