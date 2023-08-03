using AutoMapper;
using BLL.DTOs.CustomerDTO;
using BLL.Models;

namespace BLL.AutoMapper.Customer;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<SignUpModel, DAL.Entities.Customer>().AfterMap((model, customer) => {
            customer.UserName = model.FirstName + model.LastName;
            customer.EmailConfirmed = true;
            customer.PhoneNumberConfirmed = true;
        });
        CreateMap<DAL.Entities.Customer, GetCustomerDto>();
        CreateMap<DAL.Entities.Customer, UpdateCustomerDto>().ReverseMap().AfterMap((model, customer) =>
        {
            customer.UpdatedDateTime = DateTime.Now;
        });
    }
}