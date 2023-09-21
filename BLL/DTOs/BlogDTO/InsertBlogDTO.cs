using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.SVG;

namespace BLL.DTOs.BlogDTO
{
    public class InsertBlogDTO
    {
        public InsertSVGDTO SVG { get; set; } = null!;
        public List<InsertParagraphDTO> Paragraphs { get; set; } = null!;
        public List<InsertPictureDTO> Pictures { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double? ReadingTime { get; set; }
        public int Viewers { get; set; }
    }
}
