using EnglishLearningPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnglishLearningPlatform.Infrastructure.Data;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class SuggestionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SuggestionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSuggestions()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userId == null) return Unauthorized();
            var learnedLessonIds = _context.UserProgress.Where(p => p.UserId.ToString() == userId).Select(p => p.LessonId).ToList();
            var nextLesson = _context.Lessons.FirstOrDefault(l => !learnedLessonIds.Contains(l.Id));
            if (nextLesson == null) return Ok("Bạn đã hoàn thành tất cả bài học!");
            return Ok(new { nextLesson.Id, nextLesson.Title, nextLesson.CourseId });
        }
    }
}
