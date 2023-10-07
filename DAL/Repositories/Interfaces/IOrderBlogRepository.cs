using DAL.Entities;
using DAL.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderBlogRepository : IGenericRepository<OrderBlog>
    {
        public Task<OrderBlog> ChangeTypeOrderAsync(OrderBlog orderBlog, bool typeNumber);
    }

}
