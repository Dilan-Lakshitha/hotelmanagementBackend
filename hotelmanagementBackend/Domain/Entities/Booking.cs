namespace hotelmanagementBackend.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int TravelerId { get; set; }
    public int TourPlanId { get; set; }
    public int AccommodationId { get; set; }
    public int DriverId { get; set; }
    public int GuideId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
}
