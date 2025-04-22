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
            var id = await _travelerService.AddTravelerAsync(dto);
            return CreatedAtAction(nameof(GetTravelerById), new { travelerId = id }, new { travelerId = id });
        }
    
        [HttpGet("{travelerId}")]
        public async Task<IActionResult> GetTravelerById(int travelerId)
        {
            var traveler = await _travelerService.GetTravelerByIdAsync(travelerId);
            if (traveler == null) return NotFound();
            return Ok(traveler);
        }
        
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Traveler traveler)
        {
            if (id != traveler.TravelerId) return BadRequest();
            await _travelerService.UpdateTravelerAsync(traveler);
            return Ok();
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _travelerService.DeleteTravelerAsync(id);
            return Ok();
        }
    }   
}
