namespace hotelmanagementBackend.Domain.Entities;

public class BookingTour
{
    public int booking_id  { get; set; }
    public int traveler_id  { get; set; }
    public int? driver_id  { get; set; }
    public int? guide_id { get; set; }
    public decimal total_amount  { get; set; }
    public DateTime booking_date   { get; set; }
}
