using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Paragraph : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Position { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? BlogId { get; set; }
        public Project? Project { get; set; }
        public Blog? Blog { get; set; }
    }
}
