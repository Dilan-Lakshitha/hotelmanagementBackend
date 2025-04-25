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

        public async Task<Itinerary> UpdateAsync(Itinerary itinerary)
        {
            var itineraryQuery = @"
        UPDATE Itineraries SET 
            start_date = @start_date,
            end_date = @end_date
        WHERE itinerary_id = @itinerary_id";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(itineraryQuery, new
            {
                ItineraryId = itinerary.itinerary_id,
                StartDate = itinerary.start_date,
                EndDate = itinerary.end_date
            });

            foreach (var day in itinerary.DailyPlans)
            {
                var dayQuery = @"
UPDATE Itinerary_days SET 
    day_number = @day_number,
    ""date"" = @date,
    location = @location,
    activities = @activities,
    hotel_id = @hotel_id,
    location_ticket_id = @location_ticket_id
WHERE itinerary_id = @itinerary_id AND day_number = @day_number";


                await connection.ExecuteAsync(dayQuery, new
                {
                    itineraryId = itinerary.itinerary_id,
                    DayNumber = day.day_number,
                    Date = day.date,
                    Location = day.location,
                    Activities = day.activities,
                    HotelId = day.hotel_id,
                    LocationTicketId = day.location_ticket_id
                });
            }

            return itinerary;
        }


        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM Itinerary WHERE itinerary_id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}