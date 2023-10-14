using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Base;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.SVG;

namespace BLL.DTOs.BlogDTO
{
    public class GetBlogDTO : GetBaseDto
    {
        public GetSVGDTO SVG { get; set; } = null!;
        public List<GetPictureDTO> Pictures { get; set; } = null!;
        public List<GetParagraphDTO> Paragraphs { get; set; } = null!;
        public GetAuthorDTO Author { get; set; } = null!;
        public double? ReadingTime { get; set; }
        public int Viewers { get; set; }
    }
}
