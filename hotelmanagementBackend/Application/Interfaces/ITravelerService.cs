using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Interfaces;

public interface ITravelerService
{
    Task<IEnumerable<Traveler>> GetAllTravelersAsync();
    Task<Traveler> GetTravelerByIdAsync(int travelerId);
    Task<int> AddTravelerAsync(AddTravelerDto traveler);
    Task UpdateTravelerAsync(int id , AddTravelerDto traveler);
    Task DeleteTravelerAsync(int travelerId);
}