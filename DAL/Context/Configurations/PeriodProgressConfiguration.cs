using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context.Configurations
{
    public class PeriodProgressConfiguration : BaseConfiguration<PeriodProgress>
    {
        public override void Configure(EntityTypeBuilder<PeriodProgress> builder)
        {
            builder.ToTable("PeriodProgress");

            builder
                .HasOne(x => x.OrderProjectStatus)
                .WithMany(x => x.PeriodProgresses)
                .HasForeignKey(p => p.OrderProjectStatusId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

        }
    }
}
