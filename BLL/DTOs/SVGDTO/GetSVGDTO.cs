using BLL.DTOs.Base;

namespace BLL.DTOs.SVG
{
    public class GetSVGDTO : GetBaseDTO
    {
        public string Content { get; set; } = null!;
        public Guid BlogId { get; set; }
    }
}
