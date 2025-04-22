namespace hotelmanagementBackend.Domain.Entities;

public class Hotel
{
    public int HotelId { get; set; }
    public int AgencyId { get; set; }
    public string HotelName { get; set; }
    public string HotelAddress { get; set; }
    public string HotelEmail { get; set; }
    public string HotelContactNo { get; set; }
    public List<HotelRate> HotelRates { get; set; }
}