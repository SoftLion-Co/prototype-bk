using BLL.DTOs.RatingDTO;
using BLL.DTOs.Response;

namespace BLL.Services.Rating
{
    public interface IRatingService
    {
        Task<ResponseEntity<IEnumerable<GetRatingDTO>>> GetAllRatingsAsync();
        Task<ResponseEntity<GetRatingDTO>> CreateRatingAsync(InsertRatingDTO model);
        Task<ResponseEntity<IEnumerable<GetRatingDTO>>> GetAllRatingsByProjectIdAsync(Guid projectId);
    }
}
