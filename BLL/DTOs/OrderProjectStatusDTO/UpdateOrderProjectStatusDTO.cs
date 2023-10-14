using BLL.DTOs.Base;
using BLL.DTOs.CustomerDTO;

namespace BLL.DTOs.OrderProjectStatusDTO
{
    public class UpdateOrderProjectStatusDTO : UpdateBaseDTO
    {
        public Guid CustomerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ProjectStatus { get; set; }
        public bool Designer { get; set; } 
        public bool Development { get; set; }
        public bool Security { get; set; } 
    }
}
