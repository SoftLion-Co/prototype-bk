using DAL.Entities.Base;

namespace DAL.Entities
{
    public class SVG : BaseEntity
    {
        public string Content { get; set; } = null!;
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
     }
}
