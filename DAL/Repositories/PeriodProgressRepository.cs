using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;


namespace DAL.Repositories
{
    public class PeriodProgressRepository : GenericRepository<PeriodProgress>, IPeriodProgressRepository
    {
        public PeriodProgressRepository(DataContext context)
            : base(context)
        {      
        }
    }
}
