using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Configurations
{
    public class ProjectTechnologyConfiguration : IEntityTypeConfiguration<ProjectTechnology>
    {
        public void Configure(EntityTypeBuilder<ProjectTechnology> builder)
        {
            builder.ToTable("ProjectTechnology");
            builder.HasKey(pt => new { pt.ProjectId, pt.TechnologyId });

            builder
                .HasOne(x => x.Project)
                .WithMany(x => x.ProjectTechnologies)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder
               .HasOne(x => x.Technology)
               .WithMany(x => x.ProjectTechnologies)
               .HasForeignKey(x => x.TechnologyId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }
}

