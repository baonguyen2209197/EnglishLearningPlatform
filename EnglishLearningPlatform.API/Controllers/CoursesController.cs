using EnglishLearningPlatform.Application.DTOs;
using EnglishLearningPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;
        public CoursesController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllCoursesAsync());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto dto)
            => Ok(await _service.CreateCourseAsync(dto));
    }
}
