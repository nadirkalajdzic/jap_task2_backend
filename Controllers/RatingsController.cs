using jap_task2_backend.DTO.Rating;
using jap_task2_backend.Services.RatingsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace jap_task2_backend.Controllers
{
    [Authorize]
    [Route("ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService _ratingsService;

        public RatingsController(IRatingsService ratingsService) 
        {

            _ratingsService = ratingsService;

        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRating(AddRatingDTO addRating)
        {
            var response = await _ratingsService.AddRating(addRating.Value, addRating.VideoId);
            
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
