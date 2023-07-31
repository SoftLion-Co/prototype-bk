using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations.IdentityConfigs;

public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUser<Guid>> builder)
    {
        var hasher = new PasswordHasher<IdentityUser<Guid>>();
        builder.HasData(new IdentityUser<Guid>()
        {
            Id = Guid.Parse("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
            Email = "admin@gmail.com",
            EmailConfirmed = true,
            UserName = "Admin",
            PhoneNumber = "777",
            PasswordHash = hasher.HashPassword(null, "Admin_1"),
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });
    }
}