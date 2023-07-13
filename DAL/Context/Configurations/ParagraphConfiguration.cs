using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class ParagraphConfiguration : BaseConfiguration<Paragraph>
    {
        public override void Configure(EntityTypeBuilder<Paragraph> builder)
        {
            base.Configure(builder);
            builder.ToTable("paragraph");
            builder.Property(e => e.Description).HasMaxLength(4000);
            builder.Property(e => e.Title).HasMaxLength(100);
        }
    }
}
