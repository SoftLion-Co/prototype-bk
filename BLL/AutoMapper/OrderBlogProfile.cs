using BLL.DTOs.OrderBlogDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class OrderBlogProfile : BaseProfile
    {
        public OrderBlogProfile()
        {
            CreateMap< OrderBlog, GetOrderBlogDTO>().ReverseMap();
            CreateMap<InsertOrderBlogDTO,  OrderBlog>().ReverseMap();
            CreateMap<UpdateOrderBlogDTO,  OrderBlog>().ReverseMap();
        }
    }
}
