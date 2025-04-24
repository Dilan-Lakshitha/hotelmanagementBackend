using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationTicketController : ControllerBase
    {
        private readonly ILocationTicketService _service;

        public LocationTicketController(ILocationTicketService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(LocationTicketDto ticket)
        {
            var ticketLocation = await _service.AddLocationTicketAsync(ticket);
            return Ok(ticketLocation);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _service.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _service.GetTicketByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, LocationTicketDto ticket)
        {
            if (id != ticket.LocationTicketId) return BadRequest();

            var updateTicket = await _service.UpdateLocationTicketAsync(ticket);

            return Ok(updateTicket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var deleted = await _service.DeleteLocationTicketAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }

}