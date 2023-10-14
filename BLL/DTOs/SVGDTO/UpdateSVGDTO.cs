using BLL.DTOs.Base;

namespace BLL.DTOs.SVGDTO
{
    public class UpdateSVGDTO : UpdateBaseDTO
    {
        public string Url { get; set; } = null!;
        public Guid BlogId { get; set; }
    }
}
