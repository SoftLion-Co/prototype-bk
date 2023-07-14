using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class SVGConfiguration : BaseConfiguration<SVG>
    {
        public override void Configure(EntityTypeBuilder<SVG> builder)
        {

            builder.Property(e => e.Content).HasColumnType("varbinary(max)");

            builder
                .HasOne(x => x.Blog)
                .WithMany(x => x.SVGs)
                .HasForeignKey(p => p.BlogId)
                .OnDelete(deleteBehavior:DeleteBehavior.SetNull);

        }
    }
}
