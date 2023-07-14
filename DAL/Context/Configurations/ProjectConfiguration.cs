using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class ProjectConfiguration : BaseConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(30);
            builder.Property(e => e.Period).HasMaxLength(20);

            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(deleteBehavior:DeleteBehavior.SetNull);

            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(deleteBehavior:DeleteBehavior.SetNull);

            builder
                .HasMany(x => x.Paragraphs)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(deleteBehavior:DeleteBehavior.SetNull);

            builder
               .HasMany(x => x.Ratings)
               .WithOne(x => x.Project)
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(deleteBehavior:DeleteBehavior.SetNull);

            builder
               .HasMany(x => x.Pictures)
               .WithOne(x => x.Project)
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(deleteBehavior:DeleteBehavior.SetNull);
        }
    }
}
