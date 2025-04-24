using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(int driverId);
        Task<Driver> AddDriverAsync(Driver driver);
        Task UpdateDriverAsync(Driver driver);
        Task DeleteDriverAsync(int driverId);
    }   
}