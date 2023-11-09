

using BLL.DTOs.Base;

namespace BLL.DTOs.ServiceDTO
{
    public class UpdateServiceDTO : UpdateBaseDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
