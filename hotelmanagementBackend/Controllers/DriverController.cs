using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null)
                return NotFound();
            return Ok(driver);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDriver([FromBody] Driver driver)
        {
            var createdDriver = await _driverService.AddDriverAsync(driver);
            return Ok(createdDriver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] Driver driver)
        {
            if (id != driver.DriverId)
                return BadRequest("ID mismatch");

            await _driverService.UpdateDriverAsync(driver);

            // Fetch updated driver and return
            var updatedDriver = await _driverService.GetDriverByIdAsync(id);
            return Ok(updatedDriver);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            await _driverService.DeleteDriverAsync(id);
            return Ok(new { id });
        }
    }
}

