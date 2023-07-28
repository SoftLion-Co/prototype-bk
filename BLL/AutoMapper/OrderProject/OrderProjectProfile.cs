using BLL.DTOs.OrderProjectDTO;

namespace BLL.AutoMapper.OrderOrderProject
{
    public class OrderProjectProfile : BaseProfile
    {
        public OrderProjectProfile()
        {
            CreateMap<DAL.Entities.OrderProject, GetOrderProjectDTO>().ReverseMap();
            CreateMap<InsertOrderProjectDTO, DAL.Entities.OrderProject>().ReverseMap();
            CreateMap<UpdateOrderProjectDTO, DAL.Entities.OrderProject>().ReverseMap();
        }
    }
}
