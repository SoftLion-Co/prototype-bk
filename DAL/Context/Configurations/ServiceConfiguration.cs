using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context.Configurations
{
    public class ServiceConfiguration : BaseConfiguration<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {

            builder.ToTable("Service");
            builder.Property(e => e.Title).HasMaxLength(30);

            builder
               .HasMany(x => x.PeriodProgresses)
               .WithOne(x => x.Service)
               .HasForeignKey(x => x.ServiceId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

        }

    }
}
