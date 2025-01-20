using hotelmanagementBackend.Application.Services;
using hotelmanagementBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            await _userService.RegisterUserAsync(request.UserName, request.Email, request.Password);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _userService.LoginUserAsync(request.UserName,request.Password);
            return Ok(new { Token = token });
        }
    }
}
