using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderProjectRepository : GenericRepository<OrderProject>, IOrderProjectRepository
    {
        private readonly DataContext _context;
        public OrderProjectRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderProject> ChangeTypeOrderAsync(Guid id, int typeNumber)
        {
            var orderProject = await _context.Set<OrderProject>().FirstOrDefaultAsync(x => x.Id == id);
            if (orderProject == null)
            {
                throw new NullReferenceException(nameof(orderProject));
            }

            if (typeNumber == 1)
            {
                orderProject.OrderType = Enums.OrderTypeEnum.Accepted;
            }
            else if (typeNumber == 2)
            {
                orderProject.OrderType = Enums.OrderTypeEnum.Rejected;
            }

            _context.Entry(orderProject).Property(x => x.OrderType).IsModified = true;

            return orderProject;
        }

    }
}
