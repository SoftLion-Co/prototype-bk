using AutoMapper;
using BLL.DTOs.CustomerDTO;
using BLL.Models;
using DAL.Entities;

namespace BLL.AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<SignUpModel,  Customer>().AfterMap((model, customer) =>
        {
            customer.UserName = model.FirstName + model.LastName;
            customer.EmailConfirmed = true;
            customer.PhoneNumberConfirmed = true;
        });
        CreateMap< Customer, GetCustomerDto>();
        CreateMap< Customer, UpdateCustomerDto>().ReverseMap().AfterMap((model, customer) =>
        {
            customer.UpdatedDateTime = DateTime.Now;
        });
    }
}