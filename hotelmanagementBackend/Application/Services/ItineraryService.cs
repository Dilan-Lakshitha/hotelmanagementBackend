using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Services
{
    public class ItineraryService : IItineraryService
    {
        private readonly IItineraryRepository _repository;

        public ItineraryService(IItineraryRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Itinerary>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Itinerary?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<Itinerary> AddAsync(ItineraryDTO itinerary) => _repository.AddAsync(itinerary);

        public async Task<Itinerary> UpdateAsync(ItineraryDTO itineraryDto)
        {
            await _repository.UpdateAsync(itineraryDto);
            
            var itinerary = new Itinerary
            {
                itinerary_id = itineraryDto.ItineraryId ?? 0,
                start_date = itineraryDto.StartDate,
                end_date = itineraryDto.EndDate,
                DailyPlans = itineraryDto.DailyPlans.Select(day => new ItineraryDay
                {
                    itinerary_id = day.ItineraryId ?? 0,
                    day_number = day.DayNumber,
                    date = day.Date,
                    location = day.Location,
                    activities = day.Activities,
                    hotel_id = day.HotelId,
                    location_ticket_id = day.LocationTicketId
                }).ToList()
            };

            return itinerary;
        }

        
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
