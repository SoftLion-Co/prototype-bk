using BLL.DTOs.Base;

namespace BLL.DTOs.SVG
{
    public class GetSVGDTO : GetBaseDto
    {
        public string Url { get; set; } = null!;
        public Guid BlogId { get; set; }
    }
}
