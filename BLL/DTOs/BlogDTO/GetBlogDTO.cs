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
        public string SVG { get; set; } = null!;
        public List<GetPictureDTO> PictureDTOs { get; set; }
        public List<GetParagraphDTO> ParagraphDTOs { get; set; }
        public GetAuthorDTO AuthorDTO { get; set; }
        public double? ReadingTime { get; set; }
    }
}
