using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Paragraph : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? ProjectId { get; set; }
        public Guid? BlogId { get; set; }
        public Project? Project { get; set; }
        public Blog? Blog { get; set; }
    }
}
