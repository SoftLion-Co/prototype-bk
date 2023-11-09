using BLL.DTOs.Base;
using BLL.DTOs.ServiceDTO;

namespace BLL.DTOs.PeriodProgressDTO
{
    public class GetPeriodProgressDTO : GetBaseDto
    {
        public Guid OrderProjectStatusId { get; set; }
        public GetServiceDTO Service { get; set; } = null!;
        public int NumberWeek { get; set; } = 0;
        public int Progress { get; set; } = 0;
    }
}
