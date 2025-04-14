using Microsoft.EntityFrameworkCore;
using UserProfile.Entities;


namespace UserProfile.Data
{
    
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}