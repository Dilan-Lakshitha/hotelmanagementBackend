using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerService _travelerService;
    
        public TravelerController(ITravelerService travelerService)
        {
            _travelerService = travelerService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var travelers = await _travelerService.GetAllTravelersAsync();
            return Ok(travelers);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTraveler([FromBody] AddTravelerDto dto)
        {
            var travelerId = await _travelerService.AddTravelerAsync(dto);
            var traveler = await _travelerService.GetTravelerByIdAsync(travelerId);
            return Ok(traveler);
        }

    
        [HttpGet("{travelerId}")]
        public async Task<IActionResult> GetTravelerById(int travelerId)
        {
            var traveler = await _travelerService.GetTravelerByIdAsync(travelerId);
            if (traveler == null) return NotFound();
            return Ok(traveler);
        }
        
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AddTravelerDto dto)
        {
            await _travelerService.UpdateTravelerAsync(id, dto);
            var updatedTraveler = await _travelerService.GetTravelerByIdAsync(id);
            return Ok(updatedTraveler);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var traveler = await _travelerService.GetTravelerByIdAsync(id);
            if (traveler == null)
            {
                return NotFound(new { message = $"Traveler with ID {id} not found." });
            }

            await _travelerService.DeleteTravelerAsync(id);
            return Ok(new { travelerId = id });
        }

    }   
}
