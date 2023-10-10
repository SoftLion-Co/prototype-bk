using DAL.Entities;
using DAL.GenericRepository.Interface;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderProjectRepository : IGenericRepository<OrderProject>
    {
        public Task<OrderProject> ChangeTypeOrderAsync(OrderProject orderProject, bool typeNumber);
    }
}
