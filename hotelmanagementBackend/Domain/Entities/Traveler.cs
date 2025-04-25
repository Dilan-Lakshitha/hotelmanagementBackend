namespace hotelmanagementBackend.Domain.Entities;

public class Traveler
{
    public int traveler_id { get; set; }
    public int agency_id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string passport_number { get; set; }
    public string nationality { get; set; }
    public DateTime date_of_birth { get; set; }
    public string traveler_type { get; set; }
    public int? group_id { get; set; }
    public TravelerGroup? Group { get; set; } 
}
