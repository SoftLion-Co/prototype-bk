using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class BlogConfiguration : BaseConfiguration<Blog>
    {
        public override void Configure(EntityTypeBuilder<Blog> builder)
        {
            base.Configure(builder);
            builder.ToTable("blog");
            builder.Property(e => e.Title).HasMaxLength(30);
        }
    }
}
