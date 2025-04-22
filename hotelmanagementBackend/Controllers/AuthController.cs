using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Application.Services;
using hotelmanagementBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAgencyServiceRepository _agencyService;

        public AuthController(IAgencyServiceRepository agencyService)
        {
            _agencyService = agencyService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AgencyRegisterRequest request)
        {
            if (request.Password != request.ConfirmPassword)
                return BadRequest("Password and confirm password do not match.");

            await _agencyService.RegisterAgencyAsync(request.AgencyName, request.AgencyEmail, request.Password);
            return Ok("Agency registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _agencyService.LoginAgencyAsync(request.AgencyEmail, request.Password);
            return Ok(new { Token = token });
        }
    }
}
