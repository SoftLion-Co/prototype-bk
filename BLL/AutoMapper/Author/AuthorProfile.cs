using BLL.DTOs.AuthorDTO;
using DAL.Entities;
namespace BLL.AutoMapper.Blog
{
    public class AuthorProfile : BaseProfile
    {
        public AuthorProfile()
        {
            CreateMap<Author, GetAuthorDTO>().ReverseMap();

            CreateMap<Author, GetTopAuthorDTO>().ReverseMap();

            CreateMap<InsertAuthorDTO, Author>().ReverseMap();

            CreateMap<UpdateAuthorDTO, Author>().ReverseMap();
        }
    }
}
