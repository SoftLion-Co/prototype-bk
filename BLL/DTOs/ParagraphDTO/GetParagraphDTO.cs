using BLL.DTOs.Base;

namespace BLL.DTOs.ParagraphDTO
{
    public class GetParagraphDTO : GetBaseDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Position { get; set; }
        public Guid? BlogId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
