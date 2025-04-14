using UserProfile.Entities;

namespace UserProfile.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int id, User user);
    }
}