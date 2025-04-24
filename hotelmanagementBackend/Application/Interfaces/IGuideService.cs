using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IGuideService
{
    Task<IEnumerable<Guide>> GetAllGuidesAsync();
    Task<Guide> GetGuideByIdAsync(int id);
    Task<Guide> AddGuideAsync(Guide guide);
    Task<Guide> UpdateGuideAsync(Guide guide);
    Task<int> DeleteGuideAsync(int id);
}