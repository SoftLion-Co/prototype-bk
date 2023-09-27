using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.GenericRepository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext context) : base(context)
        {
        }
    }
}
