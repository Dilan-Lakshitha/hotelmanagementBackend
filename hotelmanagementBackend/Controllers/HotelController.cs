using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelController(IHotelService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddHotel([FromBody] Hotel hotel)
        {
            await _service.AddHotelWithRatesAsync(hotel);
            return Ok(new { message = "Hotel added successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            hotel.HotelId = id;
            await _service.UpdateHotelWithRatesAsync(hotel);
            return Ok(new { message = "Hotel updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _service.DeleteHotelAsync(id);
            return Ok(new { message = "Hotel deleted successfully" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _service.GetHotelByIdAsync(id);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _service.GetAllHotelsAsync();
            return Ok(hotels);
        }
    }

}

