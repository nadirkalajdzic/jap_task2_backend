using jap_task2_backend.Data;
using jap_task2_backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace jap_task2_backend.Services.RatingsService
{
    public class RatingsService: IRatingsService
    {
        private readonly DataContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public RatingsService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<bool>> AddRating(float AddValue, int AddVideoId)
        {

            ServiceResponse<bool> response = new();

            var AddUserId = GetUserId();
            var userAlreadyAddedRating = await _context.Ratings.FirstOrDefaultAsync(x => x.UserId == AddUserId && x.VideoId == AddVideoId);

            if(userAlreadyAddedRating != null)
            {
                response.Data = false;
                response.Success = false;
                response.Message = "You already rated this item";
                return response;
            }

            var addRating = new Rating
            {
                Value = AddValue,
                VideoId = AddVideoId,
                UserId = AddUserId
            };

            await _context.Ratings.AddAsync(addRating);
            await _context.SaveChangesAsync();

            response.Data = true;
            response.Success = true;
            response.Message = "Successfully added rating";

            return response;
        }

    }
}
