using AutoMapper;
using BLL.DTOs.SVG;
using BLL.DTOs.SVGDTO;

namespace BLL.AutoMapper.SVG
{
    public class SVGProfile : Profile
    {
        public SVGProfile()
        {
            CreateMap<DAL.Entities.SVG, GetSVGDTO>().ReverseMap();
            CreateMap<DAL.Entities.SVG, InsertSVGDTO>().ReverseMap();
            CreateMap<DAL.Entities.SVG, UpdateSVGDTO>().ReverseMap();
        }
        
    }
}
