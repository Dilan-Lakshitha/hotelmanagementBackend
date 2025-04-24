namespace hotelmanagementBackend.Domain.Entities;

public class Hotel
{
    public int hotel_id { get; set; }
    public int agency_id { get; set; }
    public string hotel_name { get; set; }
    public string hotel_address { get; set; }
    public string hotel_email { get; set; }
    public string hotel_Contactno { get; set; }
    public List<HotelRate> HotelRates { get; set; }
}