using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class ProjectTechnologyRepository : IProjectTechnologyRepository
    {
        private readonly DataContext _context;

        public ProjectTechnologyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteEntityByIdAsync(Guid projectId, Guid technologyId)
        {
            var projectTechnology = await _context.ProjectTechnologies.FirstOrDefaultAsync(x => x.ProjectId == projectId && x.TechnologyId == technologyId);

            if (projectTechnology == null)
            {
                throw new NullReferenceException($"Entity with this id {projectTechnology} not found");
            }
            _context.ProjectTechnologies.Remove(projectTechnology);
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologiesByIdAsync(Guid Id/*, Expression<Func<ProjectTechnology, ProjectTechnology>>? selector = null, Expression<Func<ProjectTechnology, bool>>? predicate = null, Func<IQueryable<ProjectTechnology>, IIncludableQueryable<ProjectTechnology, object>>? include = null*/)
        {
            var query = _context.ProjectTechnologies
            .Where(pt => pt.ProjectId == Id)
            .Include(pt => pt.Technology);
            /*var query = _context.ProjectTechnologies.AsNoTracking();

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (selector is not null)
            {
                query = query.Select(selector);
            }*/


            return query.Select(pt => pt.Technology);
        }

        public async Task<IEnumerable<ProjectTechnology>> GetProjectTechnologiesByIdAsync(Guid id, Expression<Func<ProjectTechnology, ProjectTechnology>>? selector = null, Expression<Func<ProjectTechnology, bool>>? predicate = null, Func<IQueryable<ProjectTechnology>, IIncludableQueryable<ProjectTechnology, object>>? include = null)
        {
            var query = _context.ProjectTechnologies.AsNoTracking();

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (selector is not null)
            {
                query = query.Select(selector);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task InsertEntityAsync(Project project, Technology technology)
        {
            var projectTechnology = new ProjectTechnology
            {
                Project= project,
                ProjectId = project.Id,
                Technology = technology,
                TechnologyId = technology.Id
            };
            await _context.ProjectTechnologies.AddAsync(projectTechnology);
        }
    }
}
