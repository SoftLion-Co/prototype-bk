using BLL.DTOs.AuthorDTO;
using BLL.DTOs.BlogDTO;
using DAL.Entities;
using System.Text;

namespace BLL.AutoMapper
{
    public class BlogProfile : BaseProfile
    {
        public BlogProfile()
        {
            CreateMap<Blog, GetBlogDTO>().ReverseMap();
            CreateMap<Blog, InsertBlogDTO>().ReverseMap();
            CreateMap<Blog, GetTopBlogDTO>().ReverseMap();
            CreateMap<Blog, UpdateBlogDTO>().ReverseMap();
        }
    }
}
