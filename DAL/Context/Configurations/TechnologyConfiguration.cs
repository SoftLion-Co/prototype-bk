using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class TechnologyConfiguration : BaseConfiguration<Technology>
    {
        public override void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable("Technology");
            builder.Property(x => x.Name).HasMaxLength(30);

            builder
                .HasMany(x => x.Projects)
                .WithOne(x => x.Technology)
                .HasForeignKey(x=>x.CountryId)
                .OnDelete(deleteBehavior:DeleteBehavior.SetNull);
        }
    }
}
