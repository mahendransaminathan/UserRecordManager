

using System.ComponentModel.DataAnnotations;

namespace UserProfile.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }        
    }
}