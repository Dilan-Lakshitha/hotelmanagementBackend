using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces;

public interface ITravelerRepository
{
    Task<IEnumerable<Traveler>> GetAllTravelersAsync();
    Task<Traveler> GetTravelerByIdAsync(int travelerId);
    Task<int> AddTravelerAsync(Traveler traveler);
    Task UpdateTravelerAsync(Traveler traveler);
    Task DeleteTravelerAsync(int travelerId);
}