namespace hotelmanagementBackend.Domain.Entities;

public class TourPlan
{
    public int TourPlanId { get; set; }
    public int AgencyId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public int NumberOfDays { get; set; }
    public string TravelerType { get; set; }
    public int MaxTravelers { get; set; }
    public int GuideId { get; set; }
    public int DriverId { get; set; }
    public int TravelerId { get; set; }
}