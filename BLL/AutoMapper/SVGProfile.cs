using AutoMapper;
using BLL.DTOs.SVG;
using BLL.DTOs.SVGDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class SVGProfile : Profile
    {
        public SVGProfile()
        {
            CreateMap< SVG, GetSVGDTO>().ReverseMap();
            CreateMap< SVG, InsertSVGDTO>().ReverseMap();
            CreateMap< SVG, UpdateSVGDTO>().ReverseMap();
        }

    }
}
