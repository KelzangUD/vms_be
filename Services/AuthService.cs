using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace vms_be.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // user credentail validation
        public async Task<bool> ValidateCredentials(string username, string password)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username && u.Password == password);
        }

        // generate token
        public string GenerateJwtToken(string userName)
        {
            var jwtSetting = _configuration.GetSection("Jwt");

            var key = Encoding.UTF8.GetBytes(jwtSetting["Key"] ?? "ThisIsVerySecretKeyThatIsAtLeast32BytesLong!");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
