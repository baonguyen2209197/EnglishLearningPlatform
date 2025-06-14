using EnglishLearningPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnglishLearningPlatform.Infrastructure.Data;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PointsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PointsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPoints()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userId == null) return Unauthorized();
            var totalScore = _context.UserProgress.Where(p => p.UserId.ToString() == userId).Sum(p => p.Score);
            var ranking = _context.UserProgress
                .GroupBy(p => p.UserId)
                .Select(g => new { UserId = g.Key, Total = g.Sum(x => x.Score) })
                .OrderByDescending(x => x.Total)
                .ToList();
            var userRank = ranking.FindIndex(x => x.UserId.ToString() == userId) + 1;
            return Ok(new { totalScore, userRank });
        }
    }
}
