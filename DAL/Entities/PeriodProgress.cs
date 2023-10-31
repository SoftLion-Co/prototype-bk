using DAL.Entities.Base;

namespace DAL.Entities
{
    public  class PeriodProgress : BaseEntity
    {
        public OrderProjectStatus OrderProjectStatus { get; set; } = null!;
        public Guid OrderProjectStatusId { get; set; }
        public int NumberWeek { get; set; } = 0;
        public int Design { get; set; } = 0;
        public int Development { get; set; } = 0;
        public int Security { get; set; } = 0;

    }
}
