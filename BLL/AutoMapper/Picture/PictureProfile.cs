using AutoMapper;
using BLL.DTOs.PictureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AutoMapper.Picture
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<DAL.Entities.Picture, GetPictureDTO>().ReverseMap();
            CreateMap<DAL.Entities.Picture, InsertPictureDTO>().ReverseMap();
            CreateMap<DAL.Entities.Picture, UpdatePictureDTO>().ReverseMap();
        }
    }
}
