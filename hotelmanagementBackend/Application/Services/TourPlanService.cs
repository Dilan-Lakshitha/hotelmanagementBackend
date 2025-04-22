using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Services
{
    public class TourPlanService : ITourPlanService
    {
        private readonly ITourPlanRepository _tourPlanRepository;

        public TourPlanService(ITourPlanRepository tourPlanRepository)
        {
            _tourPlanRepository = tourPlanRepository;
        }

        public async Task<TourPlan> GetTourPlanByIdAsync(int tourPlanId)
        {
            return await _tourPlanRepository.GetTourPlanByIdAsync(tourPlanId);
        }

        public async Task<IEnumerable<TourPlan>> GetAllTourPlansAsync()
        {
            return await _tourPlanRepository.GetAllTourPlansAsync();
        }

        public async Task AddTourPlanAsync(TourPlan tourPlan)
        {
            await _tourPlanRepository.AddTourPlanAsync(tourPlan);
        }

        public async Task UpdateTourPlanAsync(TourPlan tourPlan)
        {
            await _tourPlanRepository.UpdateTourPlanAsync(tourPlan);
        }

        public async Task DeleteTourPlanAsync(int tourPlanId)
        {
            await _tourPlanRepository.DeleteTourPlanAsync(tourPlanId);
        }
    }

}

