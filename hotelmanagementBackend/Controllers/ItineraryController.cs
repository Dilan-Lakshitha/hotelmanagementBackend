using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryService _service;

        public ItineraryController(IItineraryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var itineraries = await _service.GetAllAsync();
            return Ok(itineraries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var itinerary = await _service.GetByIdAsync(id);
            return itinerary == null ? NotFound() : Ok(itinerary);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Itinerary itinerary)
        {
            await _service.AddAsync(itinerary);
            return Ok("Itinerary added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Itinerary itinerary)
        {
            itinerary.ItineraryId = id;
            await _service.UpdateAsync(itinerary);
            return Ok("Itinerary updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Itinerary deleted successfully.");
        }
    }

}

