using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Configurations.IdentityConfigs;

public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(new List<IdentityUserRole<Guid>>()
        {
            new()
            {
                RoleId = Guid.Parse("8379b56f-7881-48ae-bf99-a29f53059332"),
                UserId = Guid.Parse("24143b4c-87a7-401d-830d-26f8eeaaa43a")
            },
            new()
            {
                RoleId = Guid.Parse("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                UserId = Guid.Parse("1d7f4741-2cb1-4baf-a1f9-65dd95208333")
            }
        });
    }
}