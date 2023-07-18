using BLL.DTOs.AuthorDTO;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.SVG;

namespace BLL.DTOs.BlogDTO
{
    public class InsertBlogDTO
    {
        public InsertSVGDTO InsertSVGDTO { get; set; } = null!;
        public List<InsertParagraphDTO> ParagraphDTOs { get; set; } = null!;
        public List<InsertPictureDTO> Pictures { get; set; } = null!;
        public GetAuthorDTO AuthorDTO { get; set; } = null!;
        public double? ReadingTime { get; set; }
    }
}
