using AutoMapper;
using BLL.DTOs.RequestDTOs;
using DAL.Entities.Base;

namespace BLL.AutoMapper
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<BaseEntity, BaseDTO>().ReverseMap();
        }
    }
}
