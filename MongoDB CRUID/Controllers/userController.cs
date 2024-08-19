using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public userController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userManager.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var user = await _userManager.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult> CreateUser(User newUser)
        {
            await _userManager.AddUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser(string id, User updatedUser)
        {
            var user = await _userManager.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.UpdateUserAsync(id, updatedUser);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
