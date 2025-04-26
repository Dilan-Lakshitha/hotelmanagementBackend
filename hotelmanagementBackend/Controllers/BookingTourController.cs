using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace hotelmanagementBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingTourController : ControllerBase
{
    private readonly IBookingTourService _bookingService;

    public BookingTourController(IBookingTourService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
    {
        if (bookingDto == null)
        {
            return BadRequest("Booking data is null.");
        }

        var bookingId = await _bookingService.CreateBookingAsync(bookingDto);
        return Ok(bookingId);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _bookingService.GetAllBookingsAsync();
        return Ok(bookings);
    }
}