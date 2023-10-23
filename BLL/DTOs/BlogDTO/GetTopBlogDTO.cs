using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Base;
using BLL.DTOs.SVG;
using BLL.DTOs.TechnologyDTO;

namespace BLL.DTOs.BlogDTO
{
    public class GetTopBlogDTO : GetTopBaseDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public GetSVGDTO SVG { get; set; } = null!;
        public GetAuthorDTO Author { get; set; } = null!;
        public List<GetTechnologyDTO> Technologies { get; set; } = null!;
    }
}
