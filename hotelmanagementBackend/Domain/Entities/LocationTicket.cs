namespace hotelmanagementBackend.Domain.Entities;

public class LocationTicket
{
    public int location_ticket_id { get; set; }
    public string location_name { get; set; }
    public string description { get; set; }
    public decimal adult_price { get; set; }
    public decimal child_price { get; set; }
    public int agency_id { get; set; }
}