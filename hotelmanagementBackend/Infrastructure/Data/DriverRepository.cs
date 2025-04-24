using Dapper;
using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Infrastructure.Data
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DapperContext _context;

        public DriverRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            var query = @"SELECT driver_id AS DriverId, agency_id AS AgencyId, name, vehicle_type AS VehicleType, vehicle_price_per_km AS VehiclePricePerKm, phone, email, license_number AS LicenseNumber, 
            vehicle_model AS VehicleModel, vehicle_number AS VehicleNumber, vehicle_capacity AS VehicleCapacity, is_available AS IsAvailable, notes FROM public.driver";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Driver>(query);
        }

        public async Task<Driver> GetDriverByIdAsync(int driverId)
        {
            var query = @"SELECT driver_id AS DriverId, agency_id AS AgencyId, name, vehicle_type AS VehicleType, vehicle_price_per_km AS VehiclePricePerKm, phone, email, license_number AS LicenseNumber, 
            vehicle_model AS VehicleModel, vehicle_number AS VehicleNumber, vehicle_capacity AS VehicleCapacity, is_available AS IsAvailable, notes FROM public.driver";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Driver>(query, new { DriverId = driverId });
        }

        public async Task<Driver> AddDriverAsync(Driver driver)
        {
            var query = @"
        INSERT INTO public.driver (
            agency_id, name, vehicle_type, vehicle_price_per_km, phone, email, license_number,
            vehicle_model, vehicle_number, vehicle_capacity, is_available, notes
        ) 
        VALUES (
            @AgencyId, @Name, @VehicleType, @VehiclePricePerKm, @Phone, @Email, @LicenseNumber,
            @VehicleModel, @VehicleNumber, @VehicleCapacity, @IsAvailable, @Notes
        )
        RETURNING driver_id AS DriverId, agency_id AS AgencyId, name, vehicle_type AS VehicleType,
                  vehicle_price_per_km AS VehiclePricePerKm, phone, email, license_number AS LicenseNumber,
                  vehicle_model AS VehicleModel, vehicle_number AS VehicleNumber, vehicle_capacity AS VehicleCapacity,
                  is_available AS IsAvailable, notes";
    
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleAsync<Driver>(query, driver);
        }


        public async Task UpdateDriverAsync(Driver driver)
        {
            var query = @"UPDATE public.driver SET agency_id = @AgencyId, name = @Name, vehicle_type = @VehicleType, vehicle_price_per_km = @VehiclePricePerKm, phone = @Phone, email = @Email, license_number = @LicenseNumber, vehicle_model = @VehicleModel, 
                         vehicle_number = @VehicleNumber, vehicle_capacity = @VehicleCapacity, is_available = @IsAvailable, notes = @Notes WHERE driver_id = @DriverId";
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