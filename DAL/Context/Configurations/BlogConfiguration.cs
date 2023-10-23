using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    public class BlogConfiguration : BaseConfiguration<Blog>
    {
        public override void Configure(EntityTypeBuilder<Blog> builder)
        {

            builder.ToTable("Blog");
            builder.Property(e => e.Title).HasMaxLength(30);

            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            builder
               .HasMany(x => x.Ratings)
               .WithOne(x => x. Blog)
               .HasForeignKey(x => x.BlogId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            builder
               .HasMany(x => x.ProjectORBlogTechnologies)
               .WithOne(x => x.Blog)
               .HasForeignKey(x => x.BlogId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

        }
    }
}
