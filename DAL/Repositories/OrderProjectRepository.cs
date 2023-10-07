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

        public async Task<OrderProject> ChangeTypeOrderAsync(OrderProject orderProject, bool typeNumber)
        {
            if (typeNumber == true)
            {
                orderProject.OrderType = Enums.OrderTypeEnum.Accepted;
            }
            else if (typeNumber == false)
            {
                orderProject.OrderType = Enums.OrderTypeEnum.Rejected;
            }

            _context.Entry(orderProject).Property(x => x.OrderType).IsModified = true;

            return orderProject;
        }

        public async Task<OrderProject> NewTypeOrderAsync(OrderProject orderProject)
        {
            orderProject.OrderType = Enums.OrderTypeEnum.New;
            return orderProject;
        }

    }
}
