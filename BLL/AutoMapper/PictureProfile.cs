using AutoMapper;
using BLL.DTOs.PictureDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap< Picture, GetPictureDTO>().ReverseMap();
            CreateMap< Picture, InsertPictureDTO>().ReverseMap();
            CreateMap< Picture, UpdatePictureDTO>().ReverseMap();
        }
    }
}
