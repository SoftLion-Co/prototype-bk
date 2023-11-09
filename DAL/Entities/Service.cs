using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Service : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<PeriodProgress> PeriodProgresses { get; set; } = null!;

    }
}
