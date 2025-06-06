﻿using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IItineraryRepository
{
    Task<IEnumerable<Itinerary>> GetAllAsync();
    Task<Itinerary?> GetByIdAsync(int id);
    Task<Itinerary> AddAsync(ItineraryDTO itinerary);
    Task<Itinerary> UpdateAsync(ItineraryDTO itinerary);
    Task DeleteAsync(int id);
}
