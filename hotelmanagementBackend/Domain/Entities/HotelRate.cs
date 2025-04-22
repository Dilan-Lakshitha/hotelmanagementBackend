namespace hotelmanagementBackend.Domain.Entities;

public class HotelRate
{
    public int RateId { get; set; }
    public int HotelId { get; set; }
    public string RateType { get; set; }
    public decimal RatePrice { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}