using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class ProjectORBlogTechnologyRepository : IProjectORBlogTechnologyRepository
    {
        private readonly DataContext _context;

        public ProjectORBlogTechnologyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteEntityByIdAsync(Project project, Blog blog, Guid technologyId)
        {
            if(project != null)
            {
                var projectTechnology = await _context.ProjectORBlogTechnologies.FirstOrDefaultAsync(x => x.ProjectId == project.Id && x.TechnologyId == technologyId);

                if (projectTechnology == null)
                {
                    throw new NullReferenceException($"Entity with this id {projectTechnology} not found");
                }
                _context.ProjectORBlogTechnologies.Remove(projectTechnology);
            }
            else
            {
                var projectTechnology = await _context.ProjectORBlogTechnologies.FirstOrDefaultAsync(x => x.BlogId == blog.Id && x.TechnologyId == technologyId);

                if (projectTechnology == null)
                {
                    throw new NullReferenceException($"Entity with this id {projectTechnology} not found");
                }
                _context.ProjectORBlogTechnologies.Remove(projectTechnology);
            }
            
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologiesByIdAsync(Project project, Blog blog)
        {
            IQueryable<ProjectORBlogTechnology> query = _context.ProjectORBlogTechnologies;
            if (blog == null)
            {
                query = query.Where(pt => pt.ProjectId == project.Id);

            }else
            {
                query = query.Where(pt => pt.BlogId == blog.Id);
            }
            return query.Select(pt => pt.Technology);
        }

        public async Task<IEnumerable<ProjectORBlogTechnology>> GetProjectTechnologiesByProjectIdAsync(Guid id, Expression<Func<ProjectORBlogTechnology, ProjectORBlogTechnology>>? selector = null, Expression<Func<ProjectORBlogTechnology, bool>>? predicate = null, Func<IQueryable<ProjectORBlogTechnology>, IIncludableQueryable<ProjectORBlogTechnology, object>>? include = null)
        {
            var query = _context.ProjectORBlogTechnologies.AsNoTracking();

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
            var projectTechnology = new ProjectORBlogTechnology
            {
                Project= project,
                ProjectId = project.Id,
                Technology = technology,
                TechnologyId = technology.Id,
                Blog = null,
                BlogId = null
            };
            await _context.ProjectORBlogTechnologies.AddAsync(projectTechnology);
        }
        public async Task InsertEntityAsync(Blog blog, Technology technology)
        {
            var projectTechnology = new ProjectORBlogTechnology
            {
                Project = null,
                ProjectId = null,
                Technology = technology,
                TechnologyId = technology.Id,
                Blog = blog,
                BlogId = blog.Id
            };
            await _context.ProjectORBlogTechnologies.AddAsync(projectTechnology);
        }
    }
}
