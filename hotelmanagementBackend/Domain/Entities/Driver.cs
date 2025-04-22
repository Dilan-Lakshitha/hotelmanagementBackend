namespace hotelmanagementBackend.Domain.Entities;

public class Driver
{
    public int DriverId { get; set; }
    public int AgencyId { get; set; }
    public string Name { get; set; }
    public string VehicleType { get; set; }
    public decimal VehiclePricePerKm { get; set; }
}