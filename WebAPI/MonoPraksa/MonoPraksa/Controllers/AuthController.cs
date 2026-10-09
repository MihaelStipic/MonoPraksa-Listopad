using Microsoft.AspNetCore.Mvc;
using MonoPraksa.Model;
using MonoPraksa.Service.Common;

namespace MonoPraksa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var ok = await _auth.RegisterAsync(request);
            if (!ok) return Conflict("Email already registered.");
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
        {
            var result = await _auth.LoginAsync(request);
            if (result == null) return Unauthorized("Invalid email or password.");
            return result;
        }
    }
}