

using BLL.DTOs.OrderBlogDTO;

namespace BLL.AutoMapper.OrderBlog
{
    public class OrderBlogProfile : BaseProfile
    {
        public OrderBlogProfile()
        {
            CreateMap<DAL.Entities.OrderBlog, GetOrderBlogDTO>().ReverseMap();
            CreateMap<InsertOrderBlogDTO, DAL.Entities.OrderBlog>().ReverseMap();
            CreateMap<UpdateOrderBlogDTO, DAL.Entities.OrderBlog>().ReverseMap();
        }
    }
}
