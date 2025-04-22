using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Infrastructure.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DapperContext _context;

        public BookingRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var query = "SELECT * FROM public.booking";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Booking>(query);
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            var query = "SELECT * FROM public.booking WHERE id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Booking>(query, new { Id = id });
        }

        public async Task AddBookingAsync(Booking booking)
        {
            var query =
                @"INSERT INTO public.booking (traveler_id, tour_plan_id, accommodation_id, driver_id, guide_id, start_date, end_date, total_price)
                      VALUES (@TravelerId, @TourPlanId, @AccommodationId, @DriverId, @GuideId, @StartDate, @EndDate, @TotalPrice)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, booking);
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            var query = @"UPDATE public.booking SET
                        traveler_id = @TravelerId,
                        tour_plan_id = @TourPlanId,
                        accommodation_id = @AccommodationId,
                        driver_id = @DriverId,
                        guide_id = @GuideId,
                        start_date = @StartDate,
                        end_date = @EndDate,
                        total_price = @TotalPrice
                      WHERE id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            var query = "DELETE FROM public.booking WHERE id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}