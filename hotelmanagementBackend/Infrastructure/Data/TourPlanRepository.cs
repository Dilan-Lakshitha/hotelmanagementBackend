using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Infrastructure.Data
{
   public class TourPlanRepository : ITourPlanRepository
{
    private readonly DapperContext _context;

    public TourPlanRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<TourPlan> GetTourPlanByIdAsync(int tourPlanId)
    {
        var query = "SELECT tourplan_id, agency_id, description, price, status, number_of_days, traveler_type, max_travelers, guide_id, driver_id, traveler_id FROM public.tour_plan WHERE tourplan_id = @TourPlanId";
        
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<TourPlan>(query, new { TourPlanId = tourPlanId });
        }
    }

    public async Task<IEnumerable<TourPlan>> GetAllTourPlansAsync()
    {
        var query = "SELECT tourplan_id, agency_id, description, price, status, number_of_days, traveler_type, max_travelers, guide_id, driver_id, traveler_id FROM public.tour_plan";
        
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryAsync<TourPlan>(query);
        }
    }

    public async Task AddTourPlanAsync(TourPlan tourPlan)
    {
        var query = @"
            INSERT INTO public.tour_plan (agency_id, description, price, status, number_of_days, traveler_type, max_travelers, guide_id, driver_id, traveler_id)
            VALUES (@AgencyId, @Description, @Price, @Status, @NumberOfDays, @TravelerType, @MaxTravelers, @GuideId, @DriverId, @TravelerId)";
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, tourPlan);
        }
    }

    public async Task UpdateTourPlanAsync(TourPlan tourPlan)
    {
        var query = @"
            UPDATE public.tour_plan
            SET agency_id = @AgencyId, description = @Description, price = @Price, status = @Status, number_of_days = @NumberOfDays, traveler_type = @TravelerType, 
                max_travelers = @MaxTravelers, guide_id = @GuideId, driver_id = @DriverId, traveler_id = @TravelerId
            WHERE tourplan_id = @TourPlanId";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, tourPlan);
        }
    }

    public async Task DeleteTourPlanAsync(int tourPlanId)
    {
        var query = "DELETE FROM public.tour_plan WHERE tourplan_id = @TourPlanId";
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { TourPlanId = tourPlanId });
        }
    }
}

   
}