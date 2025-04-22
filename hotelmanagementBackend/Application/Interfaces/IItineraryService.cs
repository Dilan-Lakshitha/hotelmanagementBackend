using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IItineraryService
{
    Task<IEnumerable<Itinerary>> GetAllAsync();
    Task<Itinerary?> GetByIdAsync(int id);
    Task AddAsync(Itinerary itinerary);
    Task UpdateAsync(Itinerary itinerary);
    Task DeleteAsync(int id);
}
