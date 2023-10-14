using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class OrderBlogRepository : GenericRepository<OrderBlog>, IOrderBlogRepository
    {
        private readonly DataContext _context;
        public OrderBlogRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderBlog> ChangeTypeOrderAsync(OrderBlog orderBlog, bool typeNumber)
        {
            if (typeNumber == true)
            {
                orderBlog.OrderType = Enums.OrderTypeEnum.Accepted;
            }
            else if(typeNumber == false)
            {
                orderBlog.OrderType = Enums.OrderTypeEnum.Rejected;
            }

            _context.Entry(orderBlog).Property(x => x.OrderType).IsModified = true;

            return orderBlog;
        }
    }
}
