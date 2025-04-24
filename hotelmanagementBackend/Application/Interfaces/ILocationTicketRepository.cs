using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces
{
    public interface ILocationTicketRepository
    {
        Task<LocationTicket> AddLocationTicketAsync(LocationTicket ticket);
        Task<IEnumerable<LocationTicket>> GetAllTicketsAsync();
        Task<LocationTicket> GetTicketByIdAsync(int id);
        Task UpdateLocationTicketAsync(LocationTicket ticket);
        Task<bool> DeleteLocationTicketAsync(int id);
    }
}
