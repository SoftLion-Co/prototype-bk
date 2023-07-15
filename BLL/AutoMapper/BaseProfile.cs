using AutoMapper;
using BLL.DTOs;
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
