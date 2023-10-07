using DAL.Entities.Base;
using DAL.Enums;

namespace DAL.Entities
{
    public class OrderProjectStatus : BaseEntity
    {
        public Customer Customer { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public ProjectStatusEnum ProjectStatus { get; set; }
        public ICollection<PeriodProgress> PeriodProgresses { get; set; } = null!;

    }
}
