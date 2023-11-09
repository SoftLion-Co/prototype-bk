using BLL.DTOs.ServiceDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class ServiceProfile : BaseProfile
    {
        public ServiceProfile()
        {
            CreateMap<Service, GetServiceDTO>().ReverseMap();
            CreateMap<InsertServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
        }
    }
}
