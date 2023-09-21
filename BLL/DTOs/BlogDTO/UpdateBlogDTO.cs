using BLL.DTOs.Base;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.SVGDTO;

namespace BLL.DTOs.BlogDTO
{
    public class UpdateBlogDTO : UpdateBaseDTO
    {
        public UpdateSVGDTO SVG { get; set; } = null!;
        public List<UpdatePictureDTO> Pictures { get; set; } = null!;
        public List<UpdateParagraphDTO> Paragraphs { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double? ReadingTime { get; set; }
        public int Viewers { get; set; }
    }
}
