using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;         
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace hotelmanagementBackend.Application.Services
{
public class AuthenticationService : IAuthenticationService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)  
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    public string GenerateTokenForAgency(Agency agency)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("uM8hGt47yQpLwD3cN5zTfR1vXsK9Ab2J");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, agency.agency_name),
                new Claim(ClaimTypes.Email, agency.agency_email),
                new Claim("agency_id", agency.agency_id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
    
}

