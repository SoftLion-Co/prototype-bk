using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Configurations
{
    internal class DescriptionConfiguration : BaseConfiguration<Description>
    {
        public override void Configure(EntityTypeBuilder<Description> builder)
        {
            base.Configure(builder);
            builder.ToTable("description");
            builder.Property(e => e.Text).HasColumnName("text").IsRequired();
        }
    }
}
