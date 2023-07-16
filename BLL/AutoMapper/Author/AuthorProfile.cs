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
            CreateMap<Author, GetAuthorDTO>().ReverseMap();
            CreateMap<Author, GetTopAuthorDTO>().ReverseMap();
            CreateMap<InsertAuthorDTO, Author>()
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => ConvertAvatar(src.Avatar)));
            CreateMap<Author, UpdateAuthorDTO>().ReverseMap()
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => ConvertAvatar(src.Avatar)));
        }
        private static byte[] ConvertAvatar(string base64String)
        {
            try
            {
                if (!string.IsNullOrEmpty(base64String))
                {
                    return Encoding.ASCII.GetBytes(base64String);
                }
            }
            catch (FormatException ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
