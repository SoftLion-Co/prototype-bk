using BLL.DTOs.Base;

namespace BLL.DTOs.SVGDTO
{
    public class UpdateSVGDTO : UpdateBaseDTO
    {
        public string Content { get; set; } = null!;
        //public Guid BlogId { get; set; }
    }
}
