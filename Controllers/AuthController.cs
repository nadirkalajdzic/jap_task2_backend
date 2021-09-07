using jap_task2_backend.DTO.User;
using jap_task2_backend.DTO.Video;
using jap_task2_backend.Models;
using jap_task2_backend.Services.AuthService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace jap_task2_backend.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO request)
        {
            ServiceResponse<int> response = await _authService.Register(
                new User { Email = request.Email, Name = request.Name, Surname = request.Surname }, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            ServiceResponse<UserLoginDTO> response = await _authService.Login(request.Email, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
