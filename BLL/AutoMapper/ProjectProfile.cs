using BLL.DTOs.ProjectDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class ProjectProfile : BaseProfile
    {
        public ProjectProfile()
        {
            CreateMap< Project, GetProjectDTO>().ForMember(dest => dest.RatingCount, opt=>opt.MapFrom(src=>src.Ratings.Count())).ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.ProjectTechnologies.Select(pt => pt.Technology)));
            CreateMap<InsertProjectDTO,  Project>().ReverseMap();
            CreateMap<UpdateProjectDTO,  Project>().ReverseMap();
        }
    }
}
