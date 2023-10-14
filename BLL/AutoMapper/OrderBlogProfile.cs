using BLL.DTOs.OrderBlogDTO;
using DAL.Entities;
using DAL.Enums;

namespace BLL.AutoMapper
{
    public class OrderBlogProfile : BaseProfile
    {
        public OrderBlogProfile()
        {
            CreateMap< OrderBlog, GetOrderBlogDTO>().ForMember(
                dest => dest.OrderType,
                opt => opt.MapFrom(src =>
                    src.OrderType == OrderTypeEnum.Accepted ? true :
                    src.OrderType == OrderTypeEnum.Rejected ? false :
                    (bool?)null
                )
            ); ;
            CreateMap<InsertOrderBlogDTO,  OrderBlog>();
            CreateMap<UpdateOrderBlogDTO,  OrderBlog>();
        }
    }
}
