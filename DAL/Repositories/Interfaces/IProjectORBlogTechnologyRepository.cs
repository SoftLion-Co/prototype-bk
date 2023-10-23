using DAL.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.Repositories.Interfaces
{
    public interface IProjectORBlogTechnologyRepository 
    {
        Task<IEnumerable<Technology>> GetAllTechnologiesByIdAsync(Project project, Blog blog);
        Task<IEnumerable<ProjectORBlogTechnology>> GetProjectTechnologiesByProjectIdAsync(Guid id, Expression<Func<ProjectORBlogTechnology, ProjectORBlogTechnology>>? selector = default, Expression<Func<ProjectORBlogTechnology, bool>>? predicate = default, Func<IQueryable<ProjectORBlogTechnology>, IIncludableQueryable<ProjectORBlogTechnology, object>>? include = default);
        Task InsertEntityAsync(Project project, Technology technology);
        Task InsertEntityAsync(Blog blog, Technology technology);
        Task DeleteEntityByIdAsync(Project project,Blog blog, Guid technologyId);
    }
}
