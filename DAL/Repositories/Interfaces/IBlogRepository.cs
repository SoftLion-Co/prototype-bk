using DAL.Entities;
using DAL.GenericRepository.Interface;

namespace DAL.Repositories.Interfaces
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
    }
}
