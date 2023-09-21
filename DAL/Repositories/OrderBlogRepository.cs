using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderBlogRepository : GenericRepository<OrderBlog>, IOrderBlogRepository
    {
        private readonly DataContext _context;
        public OrderBlogRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderBlog> ChangeTypeOrderAsync(Guid id, int typeNumber)
        {
            var orderBlog = await _context.Set<OrderBlog>().FirstOrDefaultAsync(x=>x.Id == id);
            if (orderBlog == null)
            {
                throw new NullReferenceException(nameof(orderBlog));
            }

            if (typeNumber == 1)
            {
                orderBlog.OrderType = Enums.OrderTypeEnum.Accepted;
            }
            else if(typeNumber == 2)
            {
                orderBlog.OrderType = Enums.OrderTypeEnum.Rejected;
            }

            _context.Entry(orderBlog).Property(x => x.OrderType).IsModified = true;

            return orderBlog;
        }
    }
}
