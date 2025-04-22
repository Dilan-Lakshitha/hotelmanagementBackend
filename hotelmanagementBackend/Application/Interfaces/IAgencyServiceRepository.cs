using hotelmanagementBackend.Domain.Entities;
namespace hotelmanagementBackend.Application.Interfaces
{
public interface IAgencyServiceRepository
{
    Task RegisterAgencyAsync(string name, string email, string password);
    Task<string> LoginAgencyAsync(string email, string password);
}
    
}

