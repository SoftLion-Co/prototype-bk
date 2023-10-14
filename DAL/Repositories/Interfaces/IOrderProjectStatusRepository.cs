using DAL.Entities;
using DAL.GenericRepository.Interface;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderProjectStatusRepository : IGenericRepository<OrderProjectStatus>
    {
        Task<OrderProjectStatus> ChangeTypeAsync(OrderProjectStatus orderProjectStatus, int typeNumber);
        Task<IEnumerable<OrderProjectStatus>> FindByCustomerId(Guid customerId);
    }
}
