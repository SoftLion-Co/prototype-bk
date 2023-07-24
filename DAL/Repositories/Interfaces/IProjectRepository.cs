using DAL.Entities;
using DAL.GenericRepository.Interface;
using DAL.Helpers;

namespace DAL.Repositories.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<PagedList<Project>> GetProducts(ItemParameters itemParameters);
    }
}
