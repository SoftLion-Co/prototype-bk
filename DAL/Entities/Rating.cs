using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Rating : BaseEntity
    {
        public double Mark { get; set; }
        public Project Project { get; set; } = null!;
        public Guid ProjectId { get; set; } 
    }
}
