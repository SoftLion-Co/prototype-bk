

using BLL.DTOs.ServiceDTO;

namespace BLL.DTOs.PeriodProgressDTO
{
    public class InsertPeriodProgressDTO
    {
        public Guid OrderProjectStatusId { get; set; }
        public InsertServiceDTO Service { get; set; } = null!;
        public int NumberWeek { get; set; } = 0;
        public int Progress { get; set; } = 0;
    }
}
