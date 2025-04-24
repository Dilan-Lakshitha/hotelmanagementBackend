namespace hotelmanagementBackend.Domain.Entities;

public class HotelRate
{
    public int rate_id { get; set; }
    public int hotel_id { get; set; }
    public string rate_type { get; set; }
    public decimal rate { get; set; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
}