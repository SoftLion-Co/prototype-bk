using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Configurations
{
    internal class CustomerConfiguration : BaseConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.Property(e => e.Email).HasMaxLength(30);

            builder
                .HasMany(x => x.Projects)
                .WithOne(x => x.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(deleteBehavior:DeleteBehavior.SetNull);

        }
    }
}
