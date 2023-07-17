using BLL.DTOs.BlogDTO;

namespace BLL.AutoMapper.Blog
{
    public class BlogProfile : BaseProfile
    {
        public BlogProfile()
        {
            CreateMap<GetBlogDTO, DAL.Entities.Blog>();
        }
    }
}
