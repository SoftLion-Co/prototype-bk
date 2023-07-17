using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
