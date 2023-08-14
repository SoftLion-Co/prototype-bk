using BLL.DTOs.RatingDTO;
using BLL.Services.Rating;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        /// <summary>
        /// Return all ratings about blog 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetRatingDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRatingsByProjectIdAsync(Guid id)
        {
            var response = await _ratingService.GetAllRatingsByProjectIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create rating about blog 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetRatingDTO</returns>
        [HttpPost]
        public async Task<IActionResult> InsertRatingAsync([FromBody] InsertRatingDTO insertRating)
        {
            var response = await _ratingService.InsertRatingAsync(insertRating);
            return Ok(response);
        }
    }
}
