
namespace DAL.Entities
{
    public class ProjectORBlogTechnology
    {
        public Technology Technology { get; set; } = null!;
        public Guid TechnologyId { get; set; }
        public Project? Project { get; set; } 
        public Guid? ProjectId { get; set; }
        public Blog? Blog { get; set; }
        public Guid? BlogId { get; set; }
    }
}
