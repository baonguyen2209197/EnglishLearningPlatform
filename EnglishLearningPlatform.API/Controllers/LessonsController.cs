using EnglishLearningPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnglishLearningPlatform.Infrastructure.Data;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class LessonsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LessonsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lessons = _context.Lessons.Select(l => new { l.Id, l.Title, l.Content, l.CourseId }).ToList();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var lesson = _context.Lessons.Where(l => l.Id == id).Select(l => new { l.Id, l.Title, l.Content, l.CourseId }).FirstOrDefault();
            if (lesson == null) return NotFound();
            return Ok(lesson);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] CreateLessonRequest request)
        {
            var lesson = new Lesson { Id = Guid.NewGuid(), Title = request.Title, Content = request.Content, CourseId = request.CourseId };
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return Ok(lesson);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Guid id, [FromBody] CreateLessonRequest request)
        {
            var lesson = _context.Lessons.Find(id);
            if (lesson == null) return NotFound();
            lesson.Title = request.Title;
            lesson.Content = request.Content;
            lesson.CourseId = request.CourseId;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            var lesson = _context.Lessons.Find(id);
            if (lesson == null) return NotFound();
            _context.Lessons.Remove(lesson);
            _context.SaveChanges();
            return NoContent();
        }
    }

    public class CreateLessonRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CourseId { get; set; }
    }
}
