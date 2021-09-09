using jap_task2_backend.Models;
using System.Threading.Tasks;

namespace jap_task2_backend.Services.RatingsService
{
    public interface IRatingsService
    {
        Task<ServiceResponse<bool>> AddRating(float Value, int VideoId);
    }
}
