using EnglishLearningPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnglishLearningPlatform.Infrastructure.Data;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.Select(u => new { u.Id, u.Email, u.Name, u.Role }).ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _context.Users.Where(u => u.Id == id).Select(u => new { u.Id, u.Email, u.Name, u.Role }).FirstOrDefault();
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateUserRequest request)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            user.Name = request.Name;
            user.Role = request.Role;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }

    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}
