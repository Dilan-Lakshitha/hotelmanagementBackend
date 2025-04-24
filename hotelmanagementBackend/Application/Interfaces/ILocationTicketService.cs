using hotelmanagementBackend.Domain.Entities;
using hotelmanagementBackend.Models.DTOs;

namespace hotelmanagementBackend.Application.Interfaces
{
    public interface ILocationTicketService
    {
        Task<LocationTicket> AddLocationTicketAsync(LocationTicketDto ticket);
        Task<IEnumerable<LocationTicket>> GetAllTicketsAsync();
        Task<LocationTicket> GetTicketByIdAsync(int id);
        Task<LocationTicket> UpdateLocationTicketAsync(LocationTicketDto ticket);
        Task<bool> DeleteLocationTicketAsync(int id);
    }
}

