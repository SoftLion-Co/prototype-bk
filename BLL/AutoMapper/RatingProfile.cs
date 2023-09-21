using BLL.DTOs.RatingDTO;
using DAL.Entities;

namespace BLL.AutoMapper
{
    public class RatingProfile : BaseProfile
    {
        public RatingProfile()
        {
            CreateMap< Rating, GetRatingDTO>().ReverseMap();
            CreateMap< Rating, UpdateRatingDTO>().ReverseMap();
            CreateMap< Rating, InsertRatingDTO>().ReverseMap();
        }
    }
}
