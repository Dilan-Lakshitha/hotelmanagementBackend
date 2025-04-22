using Dapper;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Infrastructure.Data
{
    public class DriverRepository
    {
        private readonly DapperContext _context;

        public DriverRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            var query = "SELECT driver_id AS DriverId, agency_id AS AgencyId, name, vehicle_type AS VehicleType, vehicle_price_per_km AS VehiclePricePerKm FROM public.driver";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Driver>(query);
        }

        public async Task<Driver> GetDriverByIdAsync(int driverId)
        {
            var query = "SELECT driver_id AS DriverId, agency_id AS AgencyId, name, vehicle_type AS VehicleType, vehicle_price_per_km AS VehiclePricePerKm FROM public.driver WHERE driver_id = @DriverId";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Driver>(query, new { DriverId = driverId });
        }

        public async Task AddDriverAsync(Driver driver)
        {
            var query = @"INSERT INTO public.driver (agency_id, name, vehicle_type, vehicle_price_per_km) 
                          VALUES (@AgencyId, @Name, @VehicleType, @VehiclePricePerKm)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, driver);
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            var query = @"UPDATE public.driver 
                          SET agency_id = @AgencyId, name = @Name, vehicle_type = @VehicleType, vehicle_price_per_km = @VehiclePricePerKm 
                          WHERE driver_id = @DriverId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, driver);
        }

        public async Task DeleteDriverAsync(int driverId)
        {
            var query = "DELETE FROM public.driver WHERE driver_id = @DriverId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { DriverId = driverId });
        }
    }   
}