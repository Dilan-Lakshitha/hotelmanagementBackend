using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourPlanController : ControllerBase
    {
        private readonly ITourPlanService _tourPlanService;

        public TourPlanController(ITourPlanService tourPlanService)
        {
            _tourPlanService = tourPlanService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTourPlanById(int id)
        {
            var tourPlan = await _tourPlanService.GetTourPlanByIdAsync(id);
            if (tourPlan == null)
            {
                return NotFound();
            }
            return Ok(tourPlan);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTourPlans()
        {
            var tourPlans = await _tourPlanService.GetAllTourPlansAsync();
            return Ok(tourPlans);
        }

        [HttpPost]
        public async Task<IActionResult> AddTourPlan([FromBody] TourPlan tourPlan)
        {
            await _tourPlanService.AddTourPlanAsync(tourPlan);
            return CreatedAtAction(nameof(GetTourPlanById), new { id = tourPlan.TourPlanId }, tourPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTourPlan(int id, [FromBody] TourPlan tourPlan)
        {
            if (id != tourPlan.TourPlanId)
            {
                return BadRequest();
            }

            await _tourPlanService.UpdateTourPlanAsync(tourPlan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourPlan(int id)
        {
            await _tourPlanService.DeleteTourPlanAsync(id);
            return NoContent();
        }
    }

}

