using BLL.DTOs.CountryDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class CountryProfile : BaseProfile
    {
        public CountryProfile()
        {
            CreateMap< Country, GetCountryDTO>().ReverseMap();

            CreateMap<InsertCountryDTO,  Country>().ReverseMap();

            CreateMap<UpdateCountryDTO,  Country>().ReverseMap();
        }
    }
}
