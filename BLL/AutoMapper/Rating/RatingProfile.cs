using BLL.DTOs.RatingDTO;

namespace BLL.AutoMapper.Rating
{
    public class RatingProfile : BaseProfile
    {
        public RatingProfile() 
        { 
            CreateMap<DAL.Entities.Rating, GetRatingDTO>().ReverseMap();
            CreateMap<DAL.Entities.Rating, UpdateRatingDTO>().ReverseMap();
            CreateMap<DAL.Entities.Rating, InsertRatingDTO>().ReverseMap();
        }
    }
}
