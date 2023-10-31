using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Base;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.RatingDTO;
using BLL.DTOs.SVG;
using BLL.DTOs.TechnologyDTO;

namespace BLL.DTOs.BlogDTO
{
    public class GetBlogDTO : GetBaseDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Viewers { get; set; }
        public GetSVGDTO SVG { get; set; } = null!;
        public List<GetPictureDTO> Pictures { get; set; } = null!;
        public List<GetParagraphDTO> Paragraphs { get; set; } = null!;
        public List<GetTechnologyDTO> Technologies { get; set; } = null!;
        public GetAuthorDTO Author { get; set; } = null!;
        public double? ReadingTime { get; set; }
        public List<GetRatingDTO> Ratings { get; set; } = null!;
    }
}
