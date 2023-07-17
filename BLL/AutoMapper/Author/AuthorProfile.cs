using AutoMapper;
using BLL.DTOs.AuthorDTO;
using DAL.Entities;
using DAL.Entities.ResponseEntity;
using System.Text;

namespace BLL.AutoMapper.Blog
{
    public class AuthorProfile : BaseProfile
    {
        public AuthorProfile()
        {
            CreateMap<Author, GetAuthorDTO>()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Convert.ToBase64String(src.Avatar)))
            .ReverseMap()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Avatar)));

            CreateMap<Author, GetTopAuthorDTO>()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Convert.ToBase64String(src.Avatar)))
            .ReverseMap()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Convert.FromBase64String(src.Avatar)));

            CreateMap<InsertAuthorDTO, Author>()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Avatar)))
            .ReverseMap()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Convert.ToBase64String(src.Avatar)));

            CreateMap<UpdateAuthorDTO, Author>()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Avatar)))
            .ReverseMap()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Convert.ToBase64String(src.Avatar)));

        }
    }
}
