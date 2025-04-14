using UserProfile.Entities;

using UserProfile.Repositories;

namespace UserProfile.Services
{
    
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }
        
        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        public async Task<User> UpdateUser(int id, User user)
        {
          
            User existingUser = await _userRepository.GetUserById(id);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found.");

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.DateOfBirth = user.DateOfBirth;

            return await _userRepository.UpdateUser(existingUser);
        }
    }
}