using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

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

        public Task AddAsync(Itinerary itinerary) => _repository.AddAsync(itinerary);

        public Task UpdateAsync(Itinerary itinerary) => _repository.UpdateAsync(itinerary);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
