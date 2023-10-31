using BLL.DTOs.Base;

namespace BLL.DTOs.PeriodProgressDTO
{
    public class UpdatePeriodProgressDTO : UpdateBaseDTO
    {
        public Guid OrderProjectStatusId { get; set; }
        public int NumberWeek { get; set; } = 0;
        public int Design { get; set; } = 0;
        public int Development { get; set; } = 0;
        public int Security { get; set; } = 0;
    }
}
