using BLL.DTOs.Base;


namespace BLL.DTOs.RatingDTO
{
    public class UpdateRatingDTO : UpdateBaseDTO
    {
        public double Mark { get; set; }
        public Guid BlogId { get; set; }
    }
}
