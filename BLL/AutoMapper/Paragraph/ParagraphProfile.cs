using AutoMapper;
using BLL.DTOs.ParagraphDTO;

namespace BLL.AutoMapper.Paragraph
{
    public class ParagraphProfile : Profile
    {
        public ParagraphProfile()
        {
            CreateMap<DAL.Entities.Paragraph, GetParagraphDTO>().ReverseMap();
            CreateMap<DAL.Entities.Paragraph, InsertParagraphDTO>().ReverseMap();
            CreateMap<DAL.Entities.Paragraph, UpdateParagraphDTO>().ReverseMap();
        }
    }
}
