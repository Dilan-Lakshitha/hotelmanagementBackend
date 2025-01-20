using hotelmanagementBackend.Domain.Entities;

namespace hotelmanagementBackend.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}
