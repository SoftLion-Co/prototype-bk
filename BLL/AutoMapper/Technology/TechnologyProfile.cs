using BLL.DTOs.TechnologyDTO;
using DAL.Entities;

namespace BLL.AutoMapper.Technology
{
    public class TechnologyProfile : BaseProfile
    {
        public TechnologyProfile()
        {
            CreateMap<DAL.Entities.Technology, GetTechnologyDTO>().ReverseMap();
            CreateMap<InsertTechnologyDTO, DAL.Entities.Technology>().ReverseMap();
            CreateMap<UpdateTechnologyDTO, DAL.Entities.Technology>().ReverseMap();
        }
    }
}
