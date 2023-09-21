using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    public class SVGConfiguration : BaseConfiguration<SVG>
    {
        public override void Configure(EntityTypeBuilder<SVG> builder)
        {
            builder.ToTable("SVG");
            builder.Property(e => e.Url).HasColumnType("varbinary(max)");

            builder
                .HasOne(x => x.Blog)
                .WithOne(x => x.SVG)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

        }
    }
}
