using AutoMapper;
using BLL.DTOs.Base;
using DAL.Entities.Base;

namespace BLL.AutoMapper
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<BaseEntity, GetBaseDTO>().ReverseMap();
            CreateMap<BaseEntity, GetTopBaseDTO>().ReverseMap();
            CreateMap<BaseEntity, UpdateBaseDTO>().ReverseMap();

        }
    }
}
