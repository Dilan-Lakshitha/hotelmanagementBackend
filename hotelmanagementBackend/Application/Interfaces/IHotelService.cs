using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IHotelService
{
    Task<Hotel> AddHotelWithRatesAsync(HotelwithRateDto hotel);
    Task<Hotel> UpdateHotelWithRatesAsync(HotelwithRateDto hotel);
    Task<int> DeleteHotelAsync(int hotelId);
    Task<Hotel> GetHotelByIdAsync(int hotelId);
    Task<IEnumerable<Hotel>> GetAllHotelsAsync();
}