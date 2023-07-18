using BLL.DTOs.Base;

namespace BLL.DTOs.ParagraphDTO
{
    public class GetParagraphDTO : GetBaseDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? BlogId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
