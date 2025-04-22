using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsAsync() => await _bookingRepository.GetAllBookingsAsync();
    public async Task<Booking> GetBookingByIdAsync(int id) => await _bookingRepository.GetBookingByIdAsync(id);
    public async Task AddBookingAsync(Booking booking) => await _bookingRepository.AddBookingAsync(booking);
    public async Task UpdateBookingAsync(Booking booking) => await _bookingRepository.UpdateBookingAsync(booking);
    public async Task DeleteBookingAsync(int id) => await _bookingRepository.DeleteBookingAsync(id);
}