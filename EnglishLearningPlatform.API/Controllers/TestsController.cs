using EnglishLearningPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnglishLearningPlatform.Infrastructure.Data;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class TestsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TestsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTests()
        {
            // TODO: Lấy danh sách bài kiểm tra mẫu (scaffold)
            return Ok(new[] {
                new { Id = 1, Name = "Vocabulary Test", Type = "Vocabulary" },
                new { Id = 2, Name = "Grammar Test", Type = "Grammar" }
            });
        }

        [HttpPost("submit")]
        public IActionResult SubmitTest([FromBody] SubmitTestRequest request)
        {
            // TODO: Xử lý chấm điểm, lưu kết quả vào UserProgress
            return Ok(new { score = 10, message = "Chấm điểm mẫu (scaffold)" });
        }
    }

    public class SubmitTestRequest
    {
        public int TestId { get; set; }
        public Dictionary<string, string> Answers { get; set; }
    }
}
