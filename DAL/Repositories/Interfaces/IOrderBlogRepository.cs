using DAL.Entities;
using DAL.GenericRepository.Interface;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderBlogRepository : IGenericRepository<OrderBlog>
    {
        public Task<OrderBlog> ChangeTypeOrderAsync(OrderBlog orderBlog, bool typeNumber);
    }

}
