using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context.Configurations
{
    public class ProjectORBlogTechnologyConfiguration : IEntityTypeConfiguration<ProjectORBlogTechnology>
    {
        public void Configure(EntityTypeBuilder<ProjectORBlogTechnology> builder)
        {
            builder.ToTable("ProjectORBlogTechnology");
            builder.HasKey(pt => new { pt.ProjectId, pt.TechnologyId });

            builder
                .HasOne(x => x.Project)
                .WithMany(x => x.ProjectORBlogTechnologies)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder
               .HasOne(x => x.Technology)
               .WithMany(x => x.ProjectORBlogTechnologies)
               .HasForeignKey(x => x.TechnologyId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.Blog)
                .WithMany(x => x.ProjectORBlogTechnologies)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }
}

