namespace hotelmanagementBackend.Domain.Entities;

public class Itinerary
{
    public int ItineraryId { get; set; }
    public int TourPlanId { get; set; }
    public int DayNumber { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string? Activities { get; set; }
    public int? HotelId { get; set; }
    public int? LocationTicketId { get; set; }
}
