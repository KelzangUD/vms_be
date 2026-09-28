using Microsoft.AspNetCore.Mvc;
using vms_be.Models;
using vms_be.Services;

namespace vms_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        { 
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Users users)
        {
            // await
            var isValid = await _authService.ValidateCredentials(users.UserName, users.Password);

            if (!isValid)
            {
                return Unauthorized(new { message = "Invalid Username or Password." });
            }

            // generate JWT token
            var token = _authService.GenerateJwtToken(users.UserName);
            return Ok(new { token, message = "Login Successful" });
        }        
    }
}
