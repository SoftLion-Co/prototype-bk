using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Technology : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<ProjectORBlogTechnology> ProjectORBlogTechnologies { get; set; } = null!;
    }
}
