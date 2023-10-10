using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderProjectStatusRepository : GenericRepository<OrderProjectStatus>, IOrderProjectStatusRepository
    {
        private readonly DataContext _context;
        public OrderProjectStatusRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderProjectStatus>> FindByCustomerId(Guid customerId)
        {
            return await _dbSet.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<OrderProjectStatus> ChangeTypeAsync(OrderProjectStatus orderProjectStatus, int typeNumber)
        {
            if (typeNumber == 0)
            {
                orderProjectStatus.ProjectStatus = Enums.ProjectStatusEnum.InProgress;
            }
            else if (typeNumber == 1)
            {
                orderProjectStatus.ProjectStatus = Enums.ProjectStatusEnum.Completed;
            }
            else if (typeNumber == 2)
            {
                orderProjectStatus.ProjectStatus = Enums.ProjectStatusEnum.OnHold;
            }
            else if (typeNumber == 3)
            {
                orderProjectStatus.ProjectStatus = Enums.ProjectStatusEnum.Canceled;
            }

            _context.Entry(orderProjectStatus).Property(x => x.ProjectStatus).IsModified = true;

            return orderProjectStatus;
        }

    }
}
