using EnglishLearningPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnglishLearningPlatform.Infrastructure.Data;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class HistoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HistoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetHistory()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userId == null) return Unauthorized();
            var history = _context.UserProgress.Where(p => p.UserId.ToString() == userId)
                .Select(p => new { p.LessonId, p.Score, p.StudyTime, p.CompletedAt })
                .OrderByDescending(p => p.CompletedAt)
                .ToList();
            return Ok(history);
        }
    }
}
