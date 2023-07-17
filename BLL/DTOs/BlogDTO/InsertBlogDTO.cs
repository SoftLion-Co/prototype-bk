using BLL.DTOs.AuthorDTO;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;

namespace BLL.DTOs.BlogDTO
{
    public class InsertBlogDTO
    {
        //public Guid Id { get; set; }
        public string SVG { get; set; }
        public List<InsertParagraphDTO> ParagraphDTOs { get; set; }
        public List<GetPictureDTO> Pictures { get; set; }
        public GetAuthorDTO AuthorDTO { get; set; }
        public double? ReadingTime { get; set; }
    }
}
