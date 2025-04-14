
using System.Collections.Generic;
using System.Threading.Tasks;
using UserProfile.Entities;
using UserProfile.Data;
using Microsoft.EntityFrameworkCore;
using UserProfile.Repositories;

namespace UserProfile.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}