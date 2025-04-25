using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Infrastructure.Data
{
    public class ItineraryRepository : IItineraryRepository
    {
        private readonly DapperContext _context;

        public ItineraryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Itinerary>> GetAllAsync()
        {
            var itineraryQuery = "SELECT * FROM Itineraries";
            var dailyPlansQuery = "SELECT * FROM Itinerary_days";

            using var connection = _context.CreateConnection();
            var itineraries = (await connection.QueryAsync<Itinerary>(itineraryQuery)).ToList();
            var allDailyPlans = await connection.QueryAsync<ItineraryDay>(dailyPlansQuery);

            foreach (var itinerary in itineraries)
            {
                itinerary.DailyPlans = allDailyPlans
                    .Where(dp => dp.itinerary_id == itinerary.itinerary_id)
                    .ToList();
            }

            return itineraries;
        }

        public async Task<Itinerary?> GetByIdAsync(int id)
        {
            var itineraryQuery = "SELECT * FROM Itineraries WHERE id = @Id";
            var dailyPlansQuery = "SELECT * FROM Itinerary_days WHERE itinerary_id = @Id";

            using var connection = _context.CreateConnection();
            var itinerary = await connection.QueryFirstOrDefaultAsync<Itinerary>(itineraryQuery, new { Id = id });
            if (itinerary != null)
            {
                var dailyPlans = await connection.QueryAsync<ItineraryDay>(dailyPlansQuery, new { Id = id });
                itinerary.DailyPlans = dailyPlans.ToList();
            }

            return itinerary;
        }


        public async Task<Itinerary> AddAsync(ItineraryDTO itineraryDTO)
        {
            var query = "INSERT INTO Itineraries (start_date, end_date) VALUES (@StartDate, @EndDate) RETURNING id;";
            using var connection = _context.CreateConnection();
            var itineraryId =
                await connection.QuerySingleAsync<int>(query, new { itineraryDTO.StartDate, itineraryDTO.EndDate });

            var itinerary = new Itinerary
            {
                itinerary_id = itineraryId,
                start_date = itineraryDTO.StartDate,
                end_date = itineraryDTO.EndDate,
                DailyPlans = new List<ItineraryDay>()
            };

            foreach (var day in itineraryDTO.DailyPlans)
            {
                var dayQuery =
                    "INSERT INTO Itinerary_days (itinerary_id, day_number, date, location, activities, hotel_id, location_ticket_id) " +
                    "VALUES (@ItineraryId, @DayNumber, @Date, @Location, @Activities, @HotelId, @LocationTicketId);";

                await connection.ExecuteAsync(dayQuery, new
                {
                    ItineraryId = itineraryId,
                    day.DayNumber,
                    day.Date,
                    day.Location,
                    day.Activities,
                    day.HotelId,
                    day.LocationTicketId
                });
            }

            return itinerary;
        }

        public async Task<Itinerary> UpdateAsync(ItineraryDTO itinerary)
        {
            var itineraryQuery = @"
        UPDATE Itineraries SET 
            start_date = @StartDate,
            end_date = @EndDate
        WHERE itinerary_id = @ItineraryId";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(itineraryQuery, new
            {
                ItineraryId = itinerary.ItineraryId,
                StartDate = itinerary.StartDate,
                EndDate = itinerary.EndDate
            });

            foreach (var day in itinerary.DailyPlans)
            {
                var dayQuery = @"
            UPDATE Itinerary_days SET 
                day_number = @DayNumber,
                date = @Date,
                location = @Location,
                activities = @Activities,
                hotel_id = @HotelId,
                location_ticket_id = @LocationTicketId
            WHERE itinerary_id = @ItineraryId AND day_number = @DayNumber";

                await connection.ExecuteAsync(dayQuery, new
                {
                    ItineraryId = itinerary.ItineraryId,
                    DayNumber = day.DayNumber,
                    Date = day.Date,
                    Location = day.Location,
                    Activities = day.Activities,
                    HotelId = day.HotelId,
                    LocationTicketId = day.LocationTicketId
                });
            }
            
            var updatedItinerary = new Itinerary
            {
                itinerary_id = itinerary.ItineraryId ?? 0,
                start_date = itinerary.StartDate,
                end_date = itinerary.EndDate,
                DailyPlans = itinerary.DailyPlans.Select(day => new ItineraryDay
                {
                    itinerary_id = day.ItineraryId ?? 0,
                    day_number = day.DayNumber,
                    date = day.Date,
                    location = day.Location,
                    activities = day.Activities,
                    hotel_id = day.HotelId,
                    location_ticket_id = day.LocationTicketId
                }).ToList()
            };

            return updatedItinerary;
        }



        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM Itineraries WHERE itinerary_id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}