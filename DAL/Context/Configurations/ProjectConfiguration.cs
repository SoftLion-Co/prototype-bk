using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class ProjectConfiguration : BaseConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Description).HasMaxLength(4000);
            builder.Property(e => e.RequestDescription).HasMaxLength(4000);
            builder.Property(e => e.RequestList).HasMaxLength(4000);
            builder.Property(e => e.SolutionDescription).HasMaxLength(4000);
            builder.Property(e => e.ResultFirstParagraph).HasMaxLength(4000);
            builder.Property(e => e.ResultSecondParagraph).HasMaxLength(4000);
            builder.Property(e => e.ResultThirdParagraph).HasMaxLength(4000);

            builder.Property(e => e.Title).HasMaxLength(30);
            builder.Property(e => e.Period).HasMaxLength(20);
        }
    }
}
