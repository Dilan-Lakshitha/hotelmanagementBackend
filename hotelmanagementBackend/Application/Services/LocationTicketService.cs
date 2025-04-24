using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Services
{
    public class LocationTicketService : ILocationTicketService
    {
        private readonly ILocationTicketRepository _repository;

        public LocationTicketService(ILocationTicketRepository repository)
        {
            _repository = repository;
        }

        public Task<LocationTicket> AddLocationTicketAsync(LocationTicketDto ticket)
        {
            var ticketLocation = new LocationTicket
            {
                location_name = ticket.LocationName,
                description = ticket.Description,
                adult_price = ticket.AdultPrice,
                child_price = ticket.ChildPrice,
                agency_id = ticket.AgencyId,
            };
            return _repository.AddLocationTicketAsync(ticketLocation);  
        }
        public Task<IEnumerable<LocationTicket>> GetAllTicketsAsync() => _repository.GetAllTicketsAsync();
        public Task<LocationTicket> GetTicketByIdAsync(int id) => _repository.GetTicketByIdAsync(id);

        public async Task<LocationTicket> UpdateLocationTicketAsync(LocationTicketDto ticket)
        {
            var updatedTicket = new LocationTicket
            {
                location_ticket_id =  ticket.LocationTicketId,
                location_name = ticket.LocationName,
                description = ticket.Description,
                adult_price = ticket.AdultPrice,
                child_price = ticket.ChildPrice,
                agency_id = ticket.AgencyId
            };
            await _repository.UpdateLocationTicketAsync(updatedTicket);

            return updatedTicket;
        }
        public Task<bool> DeleteLocationTicketAsync(int id) => _repository.DeleteLocationTicketAsync(id);
    }

}