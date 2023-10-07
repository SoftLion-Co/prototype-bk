using BLL.DTOs.Base;

namespace BLL.DTOs.OrderProjectDTO
{

    public class UpdateOrderProjectDTO : UpdateBaseDTO
    {
        public string NumberPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public bool? OrderType { get; set; } 

    }
}
