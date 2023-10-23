using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Rating : BaseEntity
    {
        public double Mark { get; set; }
        public Guid BlogId { get; set; } 
        public Blog Blog { get; set; } = null!;
    }
}
