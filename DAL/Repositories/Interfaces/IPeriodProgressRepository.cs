using DAL.Entities;
using DAL.GenericRepository.Interface;

namespace DAL.Repositories.Interfaces
{
    public interface IPeriodProgressRepository: IGenericRepository<PeriodProgress>
    {
        Task<IEnumerable<PeriodProgress>> FindByOPSId(Guid opsId);
    }
}
