using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Base;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;

namespace BLL.DTOs.BlogDTO
{
    public class GetBlogDTO : GetBaseDTO
    {
        public string SVG { get; set; } = null!;
        public List<GetPictureDTO> PictureDTOs { get; set; } = null!;
        public List<GetParagraphDTO> ParagraphDTOs { get; set; } = null!;
        public GetAuthorDTO AuthorDTO { get; set; } = null!;
        public double? ReadingTime { get; set; }
    }
}
