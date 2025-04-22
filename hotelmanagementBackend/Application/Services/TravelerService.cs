using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Services;

public class TravelerService : ITravelerService
{
    private readonly ITravelerRepository _travelerRepository;

    public TravelerService(ITravelerRepository travelerRepository)
    {
        _travelerRepository = travelerRepository;
    }

    public Task<IEnumerable<Traveler>> GetAllTravelersAsync() => _travelerRepository.GetAllTravelersAsync();

    public Task<Traveler> GetTravelerByIdAsync(int travelerId) => _travelerRepository.GetTravelerByIdAsync(travelerId);

    public async Task<int> AddTravelerAsync(AddTravelerDto dto)
    {
        var traveler = new Traveler
        {
            AgencyId = dto.AgencyId,
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            PassportNumber = dto.PassportNumber,
            Nationality = dto.Nationality,
            DateOfBirth = dto.DateOfBirth,
            TravelerType = dto.TravelerType,
            GroupId = dto.GroupId
        };

        return await _travelerRepository.AddTravelerAsync(traveler);
    }

    public Task UpdateTravelerAsync(Traveler traveler) => _travelerRepository.UpdateTravelerAsync(traveler);

    public Task DeleteTravelerAsync(int travelerId) => _travelerRepository.DeleteTravelerAsync(travelerId);
}