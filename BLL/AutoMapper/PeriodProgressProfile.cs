using BLL.DTOs.PeriodProgressDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class PeriodProgressProfile : BaseProfile
    {
        public PeriodProgressProfile()
        {
            CreateMap<PeriodProgress, GetPeriodProgressDTO>().ReverseMap();
            CreateMap<InsertPeriodProgressDTO, PeriodProgress>().ReverseMap();
            CreateMap<UpdatePeriodProgressDTO, PeriodProgress>().ReverseMap();
        }
    }

}
