using AutoMapper;
using BLL.DTOs.RequestDTOs;
using DAL.Entities;
using DAL.Entities.ResponseEntity;

namespace BLL.AutoMapper.Blog
{
    public class AuthorProfile : BaseProfile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}
