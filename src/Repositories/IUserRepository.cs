using UserProfile.Entities;

namespace UserProfile.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> UpdateUser(User user);      

    }
}