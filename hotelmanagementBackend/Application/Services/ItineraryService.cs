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

        public async Task<Itinerary> UpdateAsync(Itinerary itinerary)
        {
            await _repository.UpdateAsync(itinerary);
            return itinerary;
        }
        
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
