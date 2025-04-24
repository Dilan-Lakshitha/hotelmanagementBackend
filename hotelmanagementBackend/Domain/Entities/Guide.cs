namespace hotelmanagementBackend.Domain.Entities;
public class Guide
{
    public int GuideId { get; set; }
    public int AgencyId { get; set; }
    public string Name { get; set; }
    public string SpeakingLanguages { get; set; }
    public decimal PricePerDay { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string LicenseNumber { get; set; }
    public int YearsOfExperience { get; set; }
    public bool IsAvailable { get; set; }
    public string Notes { get; set; }
}

