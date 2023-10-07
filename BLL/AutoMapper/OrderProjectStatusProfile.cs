using BLL.DTOs.OrderProjectStatusDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class OrderProjectStatusProfile : BaseProfile
    {
        public OrderProjectStatusProfile()
        {
            CreateMap<OrderProjectStatus, GetOrderProjectStatusDTO>().ReverseMap();
            CreateMap<InsertOrderProjectStatusDTO, OrderProjectStatus>().ReverseMap();
            CreateMap<UpdateOrderProjectStatusDTO, OrderProjectStatus>().ReverseMap();
        }
    }
}
