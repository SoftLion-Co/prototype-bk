using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class OrderBlogConfiguration : BaseConfiguration<OrderBlog>
    {
        public override void Configure(EntityTypeBuilder<OrderBlog> builder)
        {
            builder.Property(x => x.Username).HasMaxLength(25);
            builder.Property(x => x.Email).HasMaxLength(30);
        }
    }
}
