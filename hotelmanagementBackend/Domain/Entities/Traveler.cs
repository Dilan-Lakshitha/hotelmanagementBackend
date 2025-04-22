namespace hotelmanagementBackend.Domain.Entities;

public class Traveler
{
    public int TravelerId { get; set; }
    public int AgencyId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PassportNumber { get; set; }
    public string Nationality { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string TravelerType { get; set; } // solo, couple, group
    public int? GroupId { get; set; } // Nullable if not in a group
}
