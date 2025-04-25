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
        var query = "SELECT * FROM Itinerary";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Itinerary>(query);
    }

    public async Task<Itinerary?> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM Itinerary WHERE itinerary_id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Itinerary>(query, new { Id = id });
    }

    public async Task<Itinerary> AddAsync(ItineraryDTO  itineraryDTO)
    {
        var query = "INSERT INTO Itineraries (StartDate, EndDate) OUTPUT INSERTED.Id VALUES (@StartDate, @EndDate);";
        using var connection = _context.CreateConnection();
        var itineraryId = await connection.QuerySingleAsync<int>(query, new { itineraryDTO.StartDate, itineraryDTO.EndDate });

        var itinerary = new Itinerary
        {
            Id = itineraryId,
            StartDate = itineraryDTO.StartDate,
            EndDate = itineraryDTO.EndDate,
            DailyPlans = new List<ItineraryDay>()
        };

        foreach (var day in itineraryDTO.DailyPlans)
        {
            var dayQuery = "INSERT INTO ItineraryDays (ItineraryId, DayNumber, Date, Location, Activities, HotelId, LocationTicketId) " +
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

    public async Task UpdateAsync(Itinerary itinerary)
    {
        var query = @"UPDATE Itinerary SET 
                        tourplan_id = @TourPlanId,
                        day_number = @DayNumber,
                        date = @Date,
                        location = @Location,
                        activities = @Activities,
                        hotel_id = @HotelId,
                        location_ticket_id = @LocationTicketId
                      WHERE itinerary_id = @ItineraryId";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, itinerary);
    }

    public async Task DeleteAsync(int id)
    {
        var query = "DELETE FROM Itinerary WHERE itinerary_id = @Id";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, new { Id = id });
    }
}

}

