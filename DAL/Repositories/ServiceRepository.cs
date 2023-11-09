
using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(DataContext context) 
            : base(context)
        { }
    }
}
