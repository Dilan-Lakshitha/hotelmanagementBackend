using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Services
{
    public class HotelService :  IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> AddHotelWithRatesAsync(HotelwithRateDto hotelDto)
        {
            var hotel = new Hotel
            {
                agency_id = hotelDto.AgencyId,
                hotel_name = hotelDto.HotelName,
                hotel_address = hotelDto.HotelAddress,
                hotel_email = hotelDto.HotelEmail,
                hotel_Contactno = hotelDto.HotelContactNo,
                HotelRates = hotelDto.HotelRates.Select(r => new HotelRate
                {
                    rate_type = r.RateType,
                    rate = r.RatePrice,
                    start_date = r.StartDate,
                    end_date = r.EndDate
                }).ToList()
            };
            
            return await _hotelRepository.AddHotelWithRates(hotel);
        }
        public async Task<Hotel> UpdateHotelWithRatesAsync(HotelwithRateDto hotelDto)
        {
            var hotel = new Hotel
            {
                hotel_id = hotelDto.HotelId.Value,
                agency_id = hotelDto.AgencyId,
                hotel_name = hotelDto.HotelName,
                hotel_address = hotelDto.HotelAddress,
                hotel_email = hotelDto.HotelEmail,
                hotel_Contactno = hotelDto.HotelContactNo,
                HotelRates = hotelDto.HotelRates.Select(r => new HotelRate
                {
                    rate_type = r.RateType,
                    rate = r.RatePrice,
                    start_date = r.StartDate,
                    end_date = r.EndDate
                }).ToList()
            };
            
            return await _hotelRepository.UpdateHotelWithRatesAsync(hotel);
        }


        public async Task<int> DeleteHotelAsync(int hotelId)
        {
            return await _hotelRepository.DeleteHotelAsync(hotelId);
        }
        public Task<Hotel> GetHotelByIdAsync(int hotelId) => _hotelRepository.GetHotelByIdAsync(hotelId);
        public Task<IEnumerable<Hotel>> GetAllHotelsAsync() => _hotelRepository.GetAllHotelsAsync();
    }
}

