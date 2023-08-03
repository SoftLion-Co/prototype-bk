using BLL.DTOs.ProjectDTO;

namespace BLL.AutoMapper.Project
{
    public class ProjectProfile : BaseProfile
    {
        public ProjectProfile()
        {
            CreateMap<DAL.Entities.Project, GetProjectDTO>().ReverseMap();
            CreateMap<InsertProjectDTO, DAL.Entities.Project>().ReverseMap();
            CreateMap<UpdateProjectDTO, DAL.Entities.Project>().ReverseMap();
        }
    }
}
