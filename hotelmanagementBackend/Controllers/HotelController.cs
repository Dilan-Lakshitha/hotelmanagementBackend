using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;
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
        public async Task<IActionResult> AddHotel([FromBody] HotelwithRateDto hotelDto)
        {
            var result = await _service.AddHotelWithRatesAsync(hotelDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelwithRateDto hotelDto)
        {
            if (id != hotelDto.HotelId)
                return BadRequest("Hotel ID mismatch");

            var updatedHotel = await _service.UpdateHotelWithRatesAsync(hotelDto);
            return Ok(updatedHotel);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var deletedId = await _service.DeleteHotelAsync(id);
            return Ok(new { deletedId });
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

