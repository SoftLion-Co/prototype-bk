using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PeriodProgressRepository : GenericRepository<PeriodProgress>, IPeriodProgressRepository
    {
        public PeriodProgressRepository(DataContext context)
            : base(context)
        {      
        }

        public async Task<IEnumerable<PeriodProgress>> FindByOPSId(Guid opsId)
        {
            return await _dbSet.Where(x => x.OrderProjectStatusId == opsId).ToListAsync();
        }
    }
}
