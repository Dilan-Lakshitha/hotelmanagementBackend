namespace hotelmanagementBackend.Domain.Entities;

public class Itinerary
{
    public int itinerary_id { get; set; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
    public List<ItineraryDay> DailyPlans { get; set; }
}

public class ItineraryDay
{
    public int id { get; set; }
    public int itinerary_id { get; set; }
    public int day_number { get; set; }
    public DateTime date { get; set; }
    public string location { get; set; }
    public string activities { get; set; }
    public int hotel_id { get; set; }
    public int location_ticket_id { get; set; }
}