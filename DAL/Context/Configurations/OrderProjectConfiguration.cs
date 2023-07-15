using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Configurations
{
    internal class OrderProjectConfiguration : BaseConfiguration<OrderProject>
    {
        public override void Configure(EntityTypeBuilder<OrderProject> builder)
        {
            builder.Property(x => x.NumberPhone).HasMaxLength(12);
            builder.Property(x => x.Email).HasMaxLength(30);
        }
    }
}
