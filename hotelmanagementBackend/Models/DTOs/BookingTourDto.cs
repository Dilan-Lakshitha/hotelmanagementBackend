namespace hotelmanagementBackend.Models.DTOs;

public class BookingDto
{
    public int TravelerId { get; set; }
    public int? DriverId { get; set; }
    public int? GuideId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<HotelBookingDto>? HotelBookings { get; set; }
    public List<LocationTicketTourDto>? LocationTickets { get; set; }
}

public class HotelBookingDto
{
    public int HotelId { get; set; }
    public int Nights { get; set; }
}

public class LocationTicketTourDto
{
    public int LocationId { get; set; }
    public int Days { get; set; }
}
