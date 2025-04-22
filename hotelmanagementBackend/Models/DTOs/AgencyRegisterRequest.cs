namespace hotelmanagementBackend.Models.DTOs;

public class AgencyRegisterRequest
{
    public string AgencyName { get; set; }
    public string AgencyEmail { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}