using BLL.DTOs.TechnologyDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class TechnologyProfile : BaseProfile
    {
        public TechnologyProfile()
        {
            CreateMap<Technology, GetTechnologyDTO>().ReverseMap();
            CreateMap<InsertTechnologyDTO, Technology>().ReverseMap();
            CreateMap<UpdateTechnologyDTO, Technology>().ReverseMap();
        }
    }
}
