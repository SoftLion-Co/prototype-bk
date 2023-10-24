using BLL.DTOs.Base;
using BLL.DTOs.OrderProjectStatusDTO;

namespace BLL.DTOs.PeriodProgressDTO
{
    public class GetPeriodProgressDTO : GetBaseDto
    {
        public Guid OrderProjectStatusId { get; set; }
        public int NumberWeek { get; set; } = 0;
        public int Designer { get; set; } = 0;
        public int Development { get; set; } = 0;
        public int Security { get; set; } = 0;
    }
}
