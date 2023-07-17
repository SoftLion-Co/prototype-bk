namespace BLL.DTOs.ParagraphDTO
{
    public class UpdateParagraphDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; } = DateTime.Now;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? BlogId { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
