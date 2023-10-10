using DAL.Entities.Base;
using DAL.Enums;

namespace DAL.Entities
{
    public class OrderProjectStatus : BaseEntity
    {
        public Customer Customer { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Designer { get; set; } = true;
        public bool Development { get; set; } =true;
        public bool Security { get; set; } = true;
        public ProjectStatusEnum ProjectStatus { get; set; }
        public ICollection<PeriodProgress> PeriodProgresses { get; set; } = null!;

    }
}
