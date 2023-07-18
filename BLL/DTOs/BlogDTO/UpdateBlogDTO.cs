using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Base;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.SVG;

namespace BLL.DTOs.BlogDTO
{
    public class UpdateBlogDTO : UpdateBaseDTO
    {
        public GetSVGDTO SVG { get; set; } = null!;
        public List<GetPictureDTO> Pictures { get; set; } = null!;
        public List<GetParagraphDTO> Paragraphs { get; set; } = null!;
        public GetAuthorDTO AuthorDTO { get; set; } = null!;
        public double? ReadingTime { get; set; }
    }
}
