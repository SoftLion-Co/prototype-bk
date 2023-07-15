using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class ParagraphConfiguration : BaseConfiguration<Paragraph>
    {
        public override void Configure(EntityTypeBuilder<Paragraph> builder)
        {
            builder.ToTable("Paragraph");
            builder.Property(e => e.Title).HasMaxLength(100);

            builder
                .HasOne(e => e.Project)
                .WithMany(e => e.Paragraphs)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Blog)
                .WithMany(e => e.Paragraphs)
                .HasForeignKey(e => e.BlogId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);
        }
    }
}
