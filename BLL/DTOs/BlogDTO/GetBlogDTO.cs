using BLL.DTOs.AuthorDTO;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;

namespace BLL.DTOs.BlogDTO
{
    public class GetBlogDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string SVG { get; set; }
        public List<GetPictureDTO> Pictures { get; set; }
        public List<GetParagraphDTO> Paragraphs { get; set; }
        public GetAuthorDTO AuthorDTO { get; set; }
        public double? ReadingTime { get; set; }
    }
}
