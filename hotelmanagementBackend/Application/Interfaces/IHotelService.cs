using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces;

public interface IHotelService
{
    Task AddHotelWithRatesAsync(Hotel hotel);
    Task UpdateHotelWithRatesAsync(Hotel hotel);
    Task DeleteHotelAsync(int hotelId);
    Task<Hotel> GetHotelByIdAsync(int hotelId);
    Task<IEnumerable<Hotel>> GetAllHotelsAsync();
}