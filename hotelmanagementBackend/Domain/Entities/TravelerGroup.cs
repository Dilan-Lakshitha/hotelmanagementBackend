namespace hotelmanagementBackend.Domain.Entities;

public class TravelerGroup
{
    public int GroupId { get; set; }
    public int AgencyId { get; set; }
    public string GroupName { get; set; }
    public int NumberOfTravelers { get; set; }
    public string Notes { get; set; }
}