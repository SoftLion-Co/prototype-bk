using BLL.DTOs.OrderProjectDTO;

using DAL.Entities;
using DAL.Enums;

namespace BLL.AutoMapper
{
    public class OrderProjectProfile : BaseProfile
    {
        public OrderProjectProfile()
        {
            CreateMap<OrderProject, GetOrderProjectDTO>()
            .ForMember(
                dest => dest.OrderType,
                opt => opt.MapFrom(src =>
                    src.OrderType == OrderTypeEnum.Accepted ? true :
                    src.OrderType == OrderTypeEnum.Rejected ? false :
                    (bool?)null
                )
            );

            CreateMap<InsertOrderProjectDTO,  OrderProject>();
            CreateMap<UpdateOrderProjectDTO,  OrderProject>();
        }
    }
}
