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
        var query = "SELECT guide_id AS GuideId, agency_id AS AgencyId, name, speaking_languages AS SpeakingLanguages, price_per_day AS PricePerDay, phone, email, license_number AS LicenseNumber,years_of_experience AS YearsOfExperience,is_available AS IsAvailable, notes FROM public.guide";
        using var connection = _context.CreateConnection();
        var guides = await connection.QueryAsync<Guide>(query);
        return guides.ToList();
    }

    public async Task<Guide> GetGuideByIdAsync(int id)
    {
        var query = "SELECT * FROM public.guide WHERE guide_id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Guide>(query, new { Id = id });
    }

    public async Task<Guide> AddGuideAsync(Guide guide)
    {
        var query = @"
        INSERT INTO public.guide 
            (agency_id, name, speaking_languages, price_per_day, phone, email, license_number, years_of_experience, is_available, notes)
        VALUES 
            (@AgencyId, @Name, @SpeakingLanguages, @PricePerDay, @Phone, @Email, @LicenseNumber, @YearsOfExperience, @IsAvailable, @Notes)
        RETURNING *;";

        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<Guide>(query, guide);
    }

    public async Task<Guide> UpdateGuideAsync(Guide guide)
    {
        var query = @"
        UPDATE public.guide
        SET agency_id = @AgencyId,
            name = @Name,
            speaking_languages = @SpeakingLanguages,
            price_per_day = @PricePerDay,
            phone = @Phone,
            email = @Email,
            license_number = @LicenseNumber,
            years_of_experience = @YearsOfExperience,
            is_available = @IsAvailable,
            notes = @Notes
        WHERE guide_id = @GuideId
        RETURNING *;";

        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<Guide>(query, guide);
    }


    public async Task<int> DeleteGuideAsync(int id)
    {
        var query = "DELETE FROM public.guide WHERE guide_id = @Id RETURNING guide_id;";
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<int>(query, new { Id = id });
    }

}