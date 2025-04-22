namespace hotelmanagementBackend.Models.DTOs;

public class AddTravelerDto
{
    public int AgencyId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PassportNumber { get; set; }
    public string Nationality { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string TravelerType { get; set; }
    public int? GroupId { get; set; }
}