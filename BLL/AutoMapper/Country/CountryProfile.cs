

using BLL.DTOs.CountryDTO;

namespace BLL.AutoMapper.Country
{
    public class CountryProfile : BaseProfile
    {
        public CountryProfile()
        {
            CreateMap<DAL.Entities.Country, GetCountryDTO>().ReverseMap();

            CreateMap<InsertCountryDTO, DAL.Entities.Country>().ReverseMap();

            CreateMap<UpdateCountryDTO, DAL.Entities.Country>().ReverseMap();
        }
    }
}
