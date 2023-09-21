using AutoMapper;
using BLL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.AutoMapper;

public class IdentityUserProfile : Profile
{
    public IdentityUserProfile()
    {
        CreateMap<SignUpModel, IdentityUser<Guid>>().AfterMap((model, user) =>
        {
            user.UserName = model.FirstName + model.LastName;
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;
        });
    }
}