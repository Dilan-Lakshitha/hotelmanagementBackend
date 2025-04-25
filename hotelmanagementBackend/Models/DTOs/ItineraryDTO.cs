namespace hotelmanagementBackend.Models.DTOs;

public class ItineraryDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<ItineraryDayDTO> DailyPlans { get; set; }
}

public class ItineraryDayDTO
{
    public int DayNumber { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Activities { get; set; }
    public int HotelId { get; set; }
    public int LocationTicketId { get; set; }
}