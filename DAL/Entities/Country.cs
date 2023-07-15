using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Project> Projects { get; set; } 

    }
}
