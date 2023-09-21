
namespace DAL.Entities
{
    public class ProjectTechnology
    {
        public Technology Technology { get; set; } = null!;
        public Guid TechnologyId { get; set; }
        public Project Project { get; set; } = null!;
        public Guid ProjectId { get; set; }
    }
}
