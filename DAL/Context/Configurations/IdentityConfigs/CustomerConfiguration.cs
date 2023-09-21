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
            builder.Property(e => e.CreatedDateTime).IsRequired();
            builder.Property(e => e.UpdatedDateTime);
            builder.HasData(new Customer()
            {
                Id = Guid.Parse("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                FirstName = "Danyil",
                LastName = "Terentiev",
                UserName = "DaniTer",
                PhoneNumber = "0505874855",
                PasswordHash = password.HashPassword(null, "Customer_1"),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            builder.HasData(new Customer()
            {
                Id = Guid.Parse("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                FirstName = "Danya",
                LastName = "Terentiev",
                UserName = "Admin",
                PhoneNumber = "777",
                PasswordHash = password.HashPassword(null, "Admin_1"),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
