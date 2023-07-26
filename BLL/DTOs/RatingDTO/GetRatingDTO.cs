using BLL.DTOs.Base;

namespace BLL.DTOs.RatingDTO
{
    public class GetRatingDTO : GetBaseDTO
    {
        public double Mark { get; set; }
        public Guid ProjectId { get; set; }
    }
}
