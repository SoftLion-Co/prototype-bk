using BLL.DTOs.OrderProjectDTO;

using DAL.Entities;
namespace BLL.AutoMapper
{
    public class OrderProjectProfile : BaseProfile
    {
        public OrderProjectProfile()
        {
            CreateMap< OrderProject, GetOrderProjectDTO>().ReverseMap();
            CreateMap<InsertOrderProjectDTO,  OrderProject>().ReverseMap();
            CreateMap<UpdateOrderProjectDTO,  OrderProject>().ReverseMap();
        }
    }
}
