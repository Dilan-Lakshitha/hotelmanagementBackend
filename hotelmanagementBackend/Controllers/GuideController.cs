using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuideController : ControllerBase
    {
        
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guides = await _guideService.GetAllGuidesAsync();
            return Ok(guides);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var guide = await _guideService.GetGuideByIdAsync(id);
            if (guide == null) return NotFound();
            return Ok(guide);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Guide guide)
        {
            await _guideService.AddGuideAsync(guide);
            return Ok(new { message = "Guide added successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Guide guide)
        {
            guide.GuideId = id;
            await _guideService.UpdateGuideAsync(guide);
            return Ok(new { message = "Guide updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _guideService.DeleteGuideAsync(id);
            return Ok(new { message = "Guide deleted successfully" });
        }
    }   
}