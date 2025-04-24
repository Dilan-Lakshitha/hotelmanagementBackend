using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public Task<IEnumerable<Driver>> GetAllDriversAsync() => _driverRepository.GetAllDriversAsync();

        public Task<Driver> GetDriverByIdAsync(int driverId) => _driverRepository.GetDriverByIdAsync(driverId);

        public Task<Driver> AddDriverAsync(Driver driver) => _driverRepository.AddDriverAsync(driver);

        public Task UpdateDriverAsync(Driver driver) => _driverRepository.UpdateDriverAsync(driver);

        public Task DeleteDriverAsync(int driverId) => _driverRepository.DeleteDriverAsync(driverId);
    }
}