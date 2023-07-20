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
            CreateMap<DAL.Entities.Blog, GetBlogDTO>().ReverseMap();
            CreateMap<DAL.Entities.Blog, InsertBlogDTO>().ReverseMap();
            CreateMap<DAL.Entities.Blog, UpdateBlogDTO>().ReverseMap();
        }
    }
}
