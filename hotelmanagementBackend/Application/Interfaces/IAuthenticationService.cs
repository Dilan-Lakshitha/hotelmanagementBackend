using hotelmanagementBackend.Domain.Entities;
namespace hotelmanagementBackend.Application.Interfaces
{
public interface IAuthenticationService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
    string GenerateTokenForAgency(Agency agency);
}
}

