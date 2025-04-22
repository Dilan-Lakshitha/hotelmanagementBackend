using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Infrastructure.Data;

public class GuideRepository : IGuideRepository
{
    private readonly DapperContext _context;

    public GuideRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Guide>> GetAllGuidesAsync()
    {
        var query = "SELECT * FROM public.guide";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Guide>(query);
    }

    public async Task<Guide> GetGuideByIdAsync(int id)
    {
        var query = "SELECT * FROM public.guide WHERE guide_id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Guide>(query, new { Id = id });
    }

    public async Task AddGuideAsync(Guide guide)
    {
        var query = @"INSERT INTO public.guide (agency_id, name, speaking_languages, price_per_day) 
                      VALUES (@AgencyId, @Name, @SpeakingLanguages, @PricePerDay)";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, guide);
    }

    public async Task UpdateGuideAsync(Guide guide)
    {
        var query = @"UPDATE public.guide 
                      SET agency_id = @AgencyId, name = @Name, speaking_languages = @SpeakingLanguages, price_per_day = @PricePerDay 
                      WHERE guide_id = @GuideId";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, guide);
    }

    public async Task DeleteGuideAsync(int id)
    {
        var query = "DELETE FROM public.guide WHERE guide_id = @Id";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, new { Id = id });
    }
}