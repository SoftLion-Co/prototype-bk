using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int Viewers { get; set; }
        public Guid? AuthorId { get; set; }
        public Author? Author { get; set; } 
        public ICollection<Paragraph> Paragraphs { get; set; } 
        public ICollection<Picture> Pictures { get; set; } 
        public ICollection<SVG> SVGs { get; set; } 

    }
}
