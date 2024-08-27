using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;

namespace MongoDB_CRUID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<adminusers>>> GetAllUsers()
        {
            var users = await _userManager.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}/GetUser")]
        public async Task<ActionResult<adminusers>> GetUserById(string id)
        {
            var user = await _userManager.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] adminusers newUser)
        {
            await _userManager.AddUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPost]
        [Route("{id}/UpdateUser")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] adminusers updatedUser)
        {
            var user = await _userManager.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.UpdateUserAsync(id, updatedUser);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}/DeleteUser")]
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
