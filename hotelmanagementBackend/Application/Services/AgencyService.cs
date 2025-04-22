using hotelmanagementBackend.Application.Interfaces;
using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Services
{
    public class AgencyService : IAgencyServiceRepository
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IAuthenticationService _authService;

        public AgencyService(IAgencyRepository agencyRepository, IAuthenticationService authService)
        {
            _agencyRepository = agencyRepository;
            _authService = authService;
        }

        public async Task RegisterAgencyAsync(string name, string email, string password)
        {
            var hashedPassword = _authService.HashPassword(password);

            var agency = new Agency
            {
                agency_name = name,
                agency_email = email,
                password = hashedPassword
            };

            await _agencyRepository.AddAgencyAsync(agency);
        }

        public async Task<string> LoginAgencyAsync(string email, string password)
        {
            var agency = await _agencyRepository.GetAgencyByEmailAsync(email);
            if (agency == null)
            {
                throw new Exception("Invalid login credentials");
            }

            if (!_authService.VerifyPassword(password, agency.password))
                throw new UnauthorizedAccessException("Invalid password");

            return _authService.GenerateTokenForAgency(agency);
        }
    }
}