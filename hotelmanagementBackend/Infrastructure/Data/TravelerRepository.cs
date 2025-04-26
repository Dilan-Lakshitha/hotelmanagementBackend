using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Infrastructure.Data;

public class TravelerRepository : ITravelerRepository
{
    private readonly DapperContext _context;

    public TravelerRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Traveler>> GetAllTravelersAsync()
    {
        var query = "SELECT * FROM public.traveler";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Traveler>(query);
    }

    public async Task<Traveler> GetTravelerByIdAsync(int travelerId)
    {
        var query = "SELECT * FROM public.traveler WHERE traveler_id = @TravelerId";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Traveler>(query, new { TravelerId = travelerId });
    }

    public async Task<int> AddTravelerAsync(Traveler traveler)
    {
        var query = @"INSERT INTO public.traveler 
                      (agency_id, name, email, phone, passport_number, nationality, date_of_birth, traveler_type, group_id) 
                      VALUES (@agency_id, @name, @email, @phone, @passport_number, @nationality, @date_of_birth, @traveler_type, @group_id)RETURNING traveler_id";
        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(query, traveler);
    }
    
    public async Task<int> AddTravelerGroupAsync(TravelerGroup group)
    {
        var query = @"INSERT INTO public.traveler_group 
                  (agency_id, number_adult, number_child, notes)
                  VALUES (@agency_id, @number_adult, @number_child, @notes)
                  RETURNING group_id";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(query, group);
    }

    public async Task UpdateTravelerAsync(Traveler traveler)
    {
        var query = @"UPDATE public.traveler SET
                        agency_id = @agency_id,
                        name = @name,
                        email = @email,
                        phone = @phone,
                        passport_number = @passport_number,
                        nationality = @nationality,
                        date_of_birth = @date_of_birth,
                        traveler_type = @traveler_type,
                        group_id = @group_id
                      WHERE traveler_id = @traveler_id";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, traveler);
    }

    public async Task DeleteTravelerAsync(int travelerId)
    {
        var query = "DELETE FROM public.traveler WHERE traveler_id = @TravelerId";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, new { TravelerId = travelerId });
    }
}