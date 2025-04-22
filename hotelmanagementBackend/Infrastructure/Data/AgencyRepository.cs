using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;


namespace hotelmanagementBackend.Infrastructure.Data
{
public class AgencyRepository : IAgencyRepository
{
    private readonly DapperContext _context;
    public AgencyRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Agency> GetAgencyByEmailAsync(string email)
    {
        var query = "SELECT * FROM public.agency WHERE agency_email = @AgencyEmail";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Agency>(query, new { AgencyEmail = email });
    }


    public async Task AddAgencyAsync(Agency user)
    {
        var query = "INSERT INTO public.agency (agency_name , agency_email, password) VALUES (@AgencyName, @AgencyEmail, @Password)";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, user);
    }
}
}

