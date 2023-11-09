using BLL.DTOs.Base;

namespace BLL.DTOs.ServiceDTO
{
    public class GetServiceDTO : GetBaseDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
