using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IItineraryRepository
{
    Task<IEnumerable<Itinerary>> GetAllAsync();
    Task<Itinerary?> GetByIdAsync(int id);
    Task AddAsync(Itinerary itinerary);
    Task UpdateAsync(Itinerary itinerary);
    Task DeleteAsync(int id);
}
