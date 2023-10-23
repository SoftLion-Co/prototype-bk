using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    public class RatingConfiguration : BaseConfiguration<Rating>
    {
        public override void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");
            builder.Property(e => e.Mark).HasColumnType("decimal(2,1)");

            builder
                .HasOne(x => x.Blog)
                .WithMany(x => x.Ratings)
                .HasForeignKey(p => p.BlogId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

        }
    }
}
