using EnglishLearningPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnglishLearningPlatform.Infrastructure.Data;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProgressController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProgressController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProgress()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userId == null) return Unauthorized();
            var progress = _context.UserProgress.Where(p => p.UserId.ToString() == userId)
                .Select(p => new { p.LessonId, p.Score, p.StudyTime, p.CompletedAt })
                .ToList();
            return Ok(progress);
        }

        [HttpPost]
        public IActionResult AddProgress([FromBody] AddProgressRequest request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userId == null) return Unauthorized();
            var progress = new UserProgress
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(userId),
                LessonId = request.LessonId,
                Score = request.Score,
                StudyTime = request.StudyTime,
                CompletedAt = DateTime.UtcNow
            };
            _context.UserProgress.Add(progress);
            _context.SaveChanges();
            return Ok(progress);
        }
    }

    public class AddProgressRequest
    {
        public Guid LessonId { get; set; }
        public int Score { get; set; }
        public TimeSpan StudyTime { get; set; }
    }
}
