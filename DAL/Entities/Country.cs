using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Project> Projects { get; set; } 

    }
}
