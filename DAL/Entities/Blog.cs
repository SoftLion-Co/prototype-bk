using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Viewers { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public ICollection<Paragraph> Paragraphs { get; set; } = null!;
        public ICollection<Picture> Pictures { get; set; } = null!;
        public ICollection<SVG> SVGs { get; set; } = null!;

    }
}
