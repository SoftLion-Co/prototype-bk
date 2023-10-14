using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DAL.Context.Configurations
{
    public class OrderProjectConfiguration : BaseConfiguration<OrderProject>
    {
        public override void Configure(EntityTypeBuilder<OrderProject> builder)
        {
            builder.ToTable("OrderProject");
            builder.Property(x => x.NumberPhone).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(30);
        }
    }
}
