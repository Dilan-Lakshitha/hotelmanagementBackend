using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IHotelRepository
{
    Task<Hotel> AddHotelWithRates(Hotel hotel);
    Task<Hotel> UpdateHotelWithRatesAsync(Hotel hotel);
    Task<int> DeleteHotelAsync(int hotelId);
    Task<Hotel> GetHotelByIdAsync(int hotelId);
    Task<IEnumerable<Hotel>> GetAllHotelsAsync();
}