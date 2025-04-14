using Microsoft.AspNetCore.Mvc;
using UserProfile.Services;
using UserProfile.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UserProfile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

            var createdUser = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }
        [HttpPut("{id}")]  
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            if (user == null || user.UserId != id)
            {
                return BadRequest("User ID mismatch or user is null");
            }
            var updatedUser = await _userService.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
    }
}