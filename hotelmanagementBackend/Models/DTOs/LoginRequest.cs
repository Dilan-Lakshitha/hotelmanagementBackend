namespace hotelmanagementBackend.Models.DTOs;

public class LoginRequest
{
    public string AgencyEmail { get; set; }
    public string Password { get; set; }
}