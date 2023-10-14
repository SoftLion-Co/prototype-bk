

using BLL.DTOs.CustomerDTO;

namespace BLL.DTOs.OrderProjectStatusDTO
{
    public class InsertOrderProjectStatusDTO
    {
        public Guid CustomerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ProjectStatus { get; set; }
        public bool Designer { get; set; } = true;
        public bool Development { get; set; } = true;
        public bool Security { get; set; } = true;
    }
}
