using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUID.Managers.IManager;
using Microsoft.AspNetCore.Identity.Data;

namespace MongoDB_CRUID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _loginManager;

        public LoginController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _loginManager.AuthenticateAsync(request.Email, request.Password);

            if (token == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new { Token = token });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Handle logout (e.g., invalidate token if using refresh tokens, etc.)
            return Ok("Logout successful");
        }
    }
}
