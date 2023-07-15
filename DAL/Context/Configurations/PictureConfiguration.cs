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
    internal class PictureConfiguration : BaseConfiguration<Picture>
    {
        public override void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture");
            builder.Property(e => e.Content).HasColumnType("varbinary(max)");

            builder
                .HasOne(x => x.Blog)
                .WithMany(x => x.Pictures)
                .HasForeignKey(p => p.BlogId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Project)
                .WithMany(x => x.Pictures)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);
        }
    }
}
