using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class BlogConfiguration : BaseConfiguration<Blog>
    {
        public override void Configure(EntityTypeBuilder<Blog> builder)
        {

            builder.ToTable("Blog");
            builder.Property(e => e.Title).HasMaxLength(30);

            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

        }
    }
}
