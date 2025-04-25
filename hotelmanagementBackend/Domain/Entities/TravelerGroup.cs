namespace hotelmanagementBackend.Domain.Entities;

public class TravelerGroup
{
    public int group_id { get; set; }
    public int agency_id { get; set; }
    public int number_adult { get; set; }
    public int number_child { get; set; }
    public string notes { get; set; }
}