namespace hotelmanagementBackend.Domain.Entities;

public class Guide
{
    public int GuideId { get; set; }
    public int AgencyId { get; set; }
    public string Name { get; set; }
    public string SpeakingLanguages { get; set; }
    public decimal PricePerDay { get; set; }
}
