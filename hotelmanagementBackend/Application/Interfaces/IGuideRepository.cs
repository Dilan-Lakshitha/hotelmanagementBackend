using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IGuideRepository
{
    Task<IEnumerable<Guide>> GetAllGuidesAsync();
    Task<Guide> GetGuideByIdAsync(int id);
    Task AddGuideAsync(Guide guide);
    Task UpdateGuideAsync(Guide guide);
    Task DeleteGuideAsync(int id);
}