using BLL.DTOs.OrderProjectStatusDTO;
using DAL.Entities;
using DAL.Enums;

namespace BLL.AutoMapper
{
    public class OrderProjectStatusProfile : BaseProfile
    {
        public OrderProjectStatusProfile()
        {
            CreateMap<OrderProjectStatus, GetOrderProjectStatusDTO>().ForMember(
                dest => dest.ProjectStatus,
                opt => opt.MapFrom(src => (int)src.ProjectStatus)
            );

            CreateMap<InsertOrderProjectStatusDTO, OrderProjectStatus>();
            CreateMap<UpdateOrderProjectStatusDTO, OrderProjectStatus>();
        }
    }
}
