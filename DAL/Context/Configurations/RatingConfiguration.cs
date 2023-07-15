using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Configurations
{
    internal class RatingConfiguration : BaseConfiguration<Rating>
    {
        public override void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");
            builder.Property(e => e.Mark).HasColumnType("decimal(2,1)");

            builder
                .HasOne(x => x.Project)
                .WithMany(x => x.Ratings)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

        }
    }
}
