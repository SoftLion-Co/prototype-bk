using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class CountryConfiguration : BaseConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {

            builder.Property(x => x.Name).HasMaxLength(30);

            builder
                .HasMany(x => x.Projects)
                .WithOne(x => x.Country)
                .HasForeignKey(x=>x.CountryId)
                .OnDelete(deleteBehavior:DeleteBehavior.SetNull);
        }
    }
}
