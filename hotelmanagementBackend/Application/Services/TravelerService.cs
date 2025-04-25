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
        int? groupId = null;

        if (dto.TravelerType == "group")
        {
            if (dto.Group != null)
            {
                var group = new TravelerGroup
                {
                    agency_id = dto.AgencyId,
                    number_adult = dto.Group.NumberAdult,
                    number_child = dto.Group.NumberChild,
                    notes = dto.Group.Notes
                };

                groupId = await _travelerRepository.AddTravelerGroupAsync(group);
            }
            else if (dto.GroupId.HasValue)
            {
                groupId = dto.GroupId;
            }
            else
            {
                throw new ArgumentException("Group info is required for group travelers");
            }
        }

        var traveler = new Traveler
        {
            agency_id = dto.AgencyId,
            name = dto.Name,
            email = dto.Email,
            phone = dto.Phone,
            passport_number = dto.PassportNumber,
            nationality = dto.Nationality,
            date_of_birth = dto.DateOfBirth,
            traveler_type = dto.TravelerType,
            group_id = groupId
        };

        return await _travelerRepository.AddTravelerAsync(traveler);
    }

    public async Task UpdateTravelerAsync(int id, AddTravelerDto dto)
    {
        int? groupId = null;

        if (dto.TravelerType == "group")
        {
            if (dto.Group != null)
            {
                var group = new TravelerGroup
                {
                    agency_id = dto.AgencyId,
                    number_adult = dto.Group.NumberAdult,
                    number_child = dto.Group.NumberChild,
                    notes = dto.Group.Notes
                };

                groupId = await _travelerRepository.AddTravelerGroupAsync(group);
            }
            else if (dto.GroupId.HasValue)
            {
                groupId = dto.GroupId;
            }
            else
            {
                throw new ArgumentException("Group info is required for group travelers");
            }
        }

        var traveler = new Traveler
        {
            traveler_id = id,
            agency_id = dto.AgencyId,
            name = dto.Name,
            email = dto.Email,
            phone = dto.Phone,
            passport_number = dto.PassportNumber,
            nationality = dto.Nationality,
            date_of_birth = dto.DateOfBirth,
            traveler_type = dto.TravelerType,
            group_id = groupId
        };

        await _travelerRepository.UpdateTravelerAsync(traveler);
    }

    public Task DeleteTravelerAsync(int travelerId) => _travelerRepository.DeleteTravelerAsync(travelerId);
}