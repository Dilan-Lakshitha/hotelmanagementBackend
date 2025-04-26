using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Services
{
    public class BookingTourService : IBookingTourService
    {
        private readonly IBookingTourRepository _bookingRepository;

        public BookingTourService(IBookingTourRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> CreateBookingAsync(BookingDto bookingDto)
        {
            var booking = new BookingTour()
            {
                traveler_id = bookingDto.TravelerId,
                driver_id = bookingDto.DriverId,
                guide_id = bookingDto.GuideId,
                total_amount = bookingDto.TotalAmount,
                booking_date = DateTime.UtcNow
            };

            var bookingId = await _bookingRepository.AddBookingAsync(booking);

            return bookingId;
        }

        public async Task<IEnumerable<BookingTour>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }
    }

}