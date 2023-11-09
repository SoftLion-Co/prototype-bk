using DAL.Entities.Base;

namespace DAL.Entities
{
    public  class PeriodProgress : BaseEntity
    {
        public OrderProjectStatus OrderProjectStatus { get; set; } = null!;
        public Guid OrderProjectStatusId { get; set; }
        public Service Service { get; set; } = null!;
        public Guid ServiceId { get; set; }
        public int NumberWeek { get; set; } = 0;
        public int Progress { get; set; } = 0;
    }
}
