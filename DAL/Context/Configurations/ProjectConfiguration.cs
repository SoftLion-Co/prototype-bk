using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    public class ProjectConfiguration : BaseConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.Property(e => e.Title).HasMaxLength(30);
            builder.Property(e => e.Period).HasMaxLength(20);

            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

            builder
               .HasMany(x => x.ProjectORBlogTechnologies)
               .WithOne(x => x.Project)
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Paragraphs)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

            builder
               .HasMany(x => x.Pictures)
               .WithOne(x => x.Project)
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(deleteBehavior:DeleteBehavior.Cascade);
        }
    }
}
