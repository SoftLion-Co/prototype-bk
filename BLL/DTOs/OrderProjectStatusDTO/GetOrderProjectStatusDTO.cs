using BLL.DTOs.Base;
using BLL.DTOs.PeriodProgressDTO;

namespace BLL.DTOs.OrderProjectStatusDTO
{
    public class GetOrderProjectStatusDTO : GetBaseDto
    {
        public List<GetPeriodProgressDTO>? PeriodProgresses { get; set; }
        public Guid CustomerId { get; set; }
        public string Title { get; set; } = null!;
        public int ProjectStatus { get; set; }
    }
}
