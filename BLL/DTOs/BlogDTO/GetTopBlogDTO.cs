using BLL.DTOs.Base;
using BLL.DTOs.SVG;

namespace BLL.DTOs.BlogDTO
{
    public class GetTopBlogDTO : GetTopBaseDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public GetSVGDTO SVG { get; set; } = null!;
    }
}
