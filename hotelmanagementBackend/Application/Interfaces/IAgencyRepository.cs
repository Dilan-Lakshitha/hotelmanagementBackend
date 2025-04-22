using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces
{
    public interface IAgencyRepository
    {
        Task AddAgencyAsync(Agency agency);
        Task<Agency> GetAgencyByEmailAsync(string email);
    }
}
