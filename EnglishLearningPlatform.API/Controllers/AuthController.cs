using EnglishLearningPlatform.Domain.Entities;
using EnglishLearningPlatform.Infrastructure.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnglishLearningPlatform.Infrastructure.Data;
using System.Security.Cryptography;
using System.Text;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtService;
        private readonly AppDbContext _context;
        public AuthController(JwtTokenService jwtService, AppDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var hash = HashPassword(request.Password);
            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email && u.PasswordHash == hash);
            if (user == null)
                return Unauthorized();
            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Email, user.Role.ToString());
            return Ok(new { token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
                return BadRequest("Email already exists");
            var user = new User { Id = Guid.NewGuid(), Email = request.Email, Name = request.Name, Role = UserRole.User, PasswordHash = HashPassword(request.Password) };
            _context.Users.Add(user);
            _context.SaveChanges();
            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Email, user.Role.ToString());
            return Ok(new { token });
        }

        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
