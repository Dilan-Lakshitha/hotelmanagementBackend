namespace hotelmanagementBackend.Domain.Entities;

public class Driver
{
    public int DriverId { get; set; }
    public int AgencyId { get; set; }
    public string Name { get; set; }
    public string VehicleType { get; set; }
    public decimal VehiclePricePerKm { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string LicenseNumber { get; set; }
    public string VehicleModel { get; set; }
    public string VehicleNumber { get; set; }
    public int VehicleCapacity { get; set; }
    public bool IsAvailable { get; set; }
    public string Notes { get; set; }
}
