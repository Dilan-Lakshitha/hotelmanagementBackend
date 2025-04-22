using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces;

public interface ITourPlanService
{
    Task<TourPlan> GetTourPlanByIdAsync(int tourPlanId);
    Task<IEnumerable<TourPlan>> GetAllTourPlansAsync();
    Task AddTourPlanAsync(TourPlan tourPlan);
    Task UpdateTourPlanAsync(TourPlan tourPlan);
    Task DeleteTourPlanAsync(int tourPlanId);
}