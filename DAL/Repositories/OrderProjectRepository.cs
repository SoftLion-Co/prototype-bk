using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderProjectRepository : GenericRepository<OrderProject>, IOrderProjectRepository
    {
        public OrderProjectRepository(DataContext context) : base(context)
        {
        }
    }
}
