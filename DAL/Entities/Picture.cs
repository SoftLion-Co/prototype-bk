using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Picture : BaseEntity
    {
        public byte[] Content { get; set; } = null!;
        public Guid? BlogId { get; set; }
        public Blog? Blog { get; set; } 
        public Guid? ProjectId { get; set; }
        public Project? Project  { get; set; } 

    }
}
