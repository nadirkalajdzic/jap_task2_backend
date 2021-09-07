using jap_task2_backend.DTO.User;
using jap_task2_backend.Models;
using System.Threading.Tasks;

namespace jap_task2_backend.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<UserLoginDTO>> Login(string email, string password);

    }
}
