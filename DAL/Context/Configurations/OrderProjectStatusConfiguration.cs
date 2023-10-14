using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context.Configurations
{
    public class OrderProjectStatusConfiguration : BaseConfiguration<OrderProjectStatus>
    {
        public override void Configure(EntityTypeBuilder<OrderProjectStatus> builder)
        {
            builder.ToTable("OrderProjectStatus");

            builder
                .HasMany(x => x.PeriodProgresses)
                .WithOne(x => x.OrderProjectStatus)
                .HasForeignKey(p => p.OrderProjectStatusId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.OrderProjectStatuses)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

        }
    }
}
