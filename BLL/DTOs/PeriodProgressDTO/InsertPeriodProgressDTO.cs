

namespace BLL.DTOs.PeriodProgressDTO
{
    public class InsertPeriodProgressDTO
    {

        public Guid OrderProjectStatusId { get; set; }
        public int NumberWeek { get; set; } = 0;
        public int Designer { get; set; } = 0;
        public int Development { get; set; } = 0;
        public int Security { get; set; } = 0;
    }
}
