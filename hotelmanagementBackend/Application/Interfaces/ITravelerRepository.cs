using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Interfaces;

public interface ITravelerRepository
{
    Task<IEnumerable<Traveler>> GetAllTravelersAsync();
    Task<Traveler> GetTravelerByIdAsync(int travelerId);
    Task<int> AddTravelerAsync(Traveler traveler);
    Task<int> AddTravelerGroupAsync(TravelerGroup group);
    Task UpdateTravelerAsync(Traveler traveler);
    Task DeleteTravelerAsync(int travelerId);
}