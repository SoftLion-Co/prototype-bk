using DAL.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.Repositories.Interfaces
{
    public interface IProjectTechnologyRepository 
    {
        Task<IEnumerable<Technology>> GetAllTechnologiesByIdAsync(Guid Id/*,
            Expression<Func<ProjectTechnology, ProjectTechnology>>? selector = default,
            Expression<Func<ProjectTechnology, bool>>? predicate = default,
            Func<IQueryable<ProjectTechnology>, IIncludableQueryable<ProjectTechnology, object>>? include = default*/);
        Task<IEnumerable<ProjectTechnology>> GetProjectTechnologiesByIdAsync(Guid id, Expression<Func<ProjectTechnology, ProjectTechnology>>? selector = default, Expression<Func<ProjectTechnology, bool>>? predicate = default, Func<IQueryable<ProjectTechnology>, IIncludableQueryable<ProjectTechnology, object>>? include = default);
        Task InsertEntityAsync(Project project, Technology technology);
        Task DeleteEntityByIdAsync(Guid projectId, Guid technologyId);
    }
}
