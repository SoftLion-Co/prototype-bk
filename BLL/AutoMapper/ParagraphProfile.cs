using AutoMapper;
using BLL.DTOs.ParagraphDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class ParagraphProfile : Profile
    {
        public ParagraphProfile()
        {
            CreateMap< Paragraph, GetParagraphDTO>().ReverseMap();
            CreateMap< Paragraph, InsertParagraphDTO>().ReverseMap();
            CreateMap< Paragraph, UpdateParagraphDTO>().ReverseMap();
        }
    }
}
