using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations.IdentityConfigs
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var password = new PasswordHasher<Customer>();
            builder.ToTable("Customer");
            // builder.Property(e => e.Email).HasMaxLength(30);
            builder.Property(e => e.CreatedDateTime).IsRequired();
            builder.Property(e => e.UpdatedDateTime);
            // builder
            //     .HasMany(x => x.Projects)
            //     .WithOne(x => x.Customer)
            //     .HasForeignKey(p => p.CustomerId)
            //     .OnDelete(deleteBehavior:DeleteBehavior.SetNull);

            builder.HasData(new Customer()
            {
                Id = Guid.Parse("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                FirstName = "Danyil",
                LastName = "Terentiev",
                UserName = "DaniTer",
                Facebook = "facebook",
                Google = "google",
                LinkedIn = "Linkedin",
                PhoneNumber = "0505874855",
                PasswordHash = password.HashPassword(null, "Customer_1"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

        }
    }
}
