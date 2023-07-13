using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public int Viewers { get; set; }
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
