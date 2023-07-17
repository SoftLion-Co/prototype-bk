using BLL.DTOs.AuthorDTO;
using BLL.DTOs.BlogDTO;
using DAL.Entities;
using System.Text;

namespace BLL.AutoMapper.Blog
{
    public class BlogProfile : BaseProfile
    {
        public BlogProfile()
        {
            CreateMap<DAL.Entities.Blog, GetBlogDTO>()
            .ForMember(dest => dest.AuthorDTO.Avatar, opt => opt.MapFrom(src => Convert.ToBase64String(src.Author.Avatar)))
            .ReverseMap()
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => Encoding.ASCII.GetBytes(src.Avatar)));
        }
    }
}
