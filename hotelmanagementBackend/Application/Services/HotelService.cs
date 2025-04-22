using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Services
{
    public class HotelService :  IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task AddHotelWithRatesAsync(Hotel hotel)
        {
            await _hotelRepository.AddHotelWithRatesAsync(hotel);
        }
        public Task UpdateHotelWithRatesAsync(Hotel hotel) => _hotelRepository.UpdateHotelWithRatesAsync(hotel);
        public Task DeleteHotelAsync(int hotelId) => _hotelRepository.DeleteHotelAsync(hotelId);
        public Task<Hotel> GetHotelByIdAsync(int hotelId) => _hotelRepository.GetHotelByIdAsync(hotelId);
        public Task<IEnumerable<Hotel>> GetAllHotelsAsync() => _hotelRepository.GetAllHotelsAsync();
    }
}

