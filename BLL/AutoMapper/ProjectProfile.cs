using BLL.DTOs.ProjectDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class ProjectProfile : BaseProfile
    {
        public ProjectProfile()
        {
            CreateMap< Project, GetProjectDTO>().ReverseMap();
            CreateMap<Project, GetTopProjectDTO>().ReverseMap();
            CreateMap<InsertProjectDTO,  Project>().ReverseMap();
            CreateMap<UpdateProjectDTO,  Project>().ReverseMap();
        }
    }
}
