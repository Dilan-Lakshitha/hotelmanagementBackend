using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

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

    public async Task AddAsync(Itinerary itinerary)
    {
        var query = @"INSERT INTO Itinerary (tourplan_id, day_number, date, location, activities, hotel_id, location_ticket_id)
                      VALUES (@TourPlanId, @DayNumber, @Date, @Location, @Activities, @HotelId, @LocationTicketId)";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, itinerary);
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

