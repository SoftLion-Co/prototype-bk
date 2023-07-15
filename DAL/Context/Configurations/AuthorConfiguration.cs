
﻿using DAL.Context.Configurations.Base;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations
{
    internal class AuthorConfiguration : BaseConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.Property(e => e.FullName).HasMaxLength(60);
            builder.Property(e => e.Employment).HasMaxLength(50);

            builder
                .HasMany(x => x.Blogs)
                .WithOne(x => x.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(deleteBehavior:DeleteBehavior.SetNull);

        }
    }
}
