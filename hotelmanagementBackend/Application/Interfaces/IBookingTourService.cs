using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IBookingTourService
{
    Task<int> CreateBookingAsync(BookingDto bookingDto);
    Task<IEnumerable<BookingTour>> GetAllBookingsAsync();
}