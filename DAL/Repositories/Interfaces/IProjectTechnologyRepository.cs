using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IProjectTechnologyRepository 
    {
        IQueryable<Technology> GetAllTechnologiesAsync(Guid Id);
    }
}
