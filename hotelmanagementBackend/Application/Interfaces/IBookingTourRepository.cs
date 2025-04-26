using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IBookingTourRepository
{
    Task<int> AddBookingAsync(BookingTour booking);
    Task<IEnumerable<BookingTour>> GetAllBookingsAsync();
}