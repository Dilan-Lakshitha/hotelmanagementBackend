using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Services
{
    public class LocationTicketService : ILocationTicketService
    {
        private readonly ILocationTicketRepository _repository;

        public LocationTicketService(ILocationTicketRepository repository)
        {
            _repository = repository;
        }

        public Task<int> AddLocationTicketAsync(LocationTicket ticket) => _repository.AddLocationTicketAsync(ticket);
        public Task<IEnumerable<LocationTicket>> GetAllTicketsAsync() => _repository.GetAllTicketsAsync();
        public Task<LocationTicket> GetTicketByIdAsync(int id) => _repository.GetTicketByIdAsync(id);
        public Task<bool> UpdateLocationTicketAsync(LocationTicket ticket) => _repository.UpdateLocationTicketAsync(ticket);
        public Task<bool> DeleteLocationTicketAsync(int id) => _repository.DeleteLocationTicketAsync(id);
    }

}