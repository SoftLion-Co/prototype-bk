using BLL.DTOs.Base;
using Microsoft.AspNetCore.Http;

namespace BLL.DTOs.SVGDTO
{
    public class UpdateSVGDTO : UpdateBaseDTO
    {
        public IFormFile Url { get; set; } = null!;
        public Guid BlogId { get; set; }
    }
}
