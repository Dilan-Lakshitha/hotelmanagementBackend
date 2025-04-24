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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Guide guide)
        {
            var createdGuide = await _guideService.AddGuideAsync(guide);
            return Ok(createdGuide);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Guide guide)
        {
            guide.GuideId = id;
            var updatedGuide = await _guideService.UpdateGuideAsync(guide);
            return Ok(updatedGuide);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedId = await _guideService.DeleteGuideAsync(id);
            return Ok(new { deletedId });
        }
    }   
}