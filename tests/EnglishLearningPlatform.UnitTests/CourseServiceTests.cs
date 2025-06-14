using Xunit;
using EnglishLearningPlatform.Application.Services;
using EnglishLearningPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EnglishLearningPlatform.Application.Mapping;
using EnglishLearningPlatform.Application.DTOs;

namespace EnglishLearningPlatform.UnitTests
{
    public class CourseServiceTests
    {
        private readonly CourseService _service;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CourseServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new AppDbContext(options);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
            _service = new CourseService(_context, _mapper);
        }

        [Fact]
        public async Task CreateCourse_ShouldReturnCourseDto()
        {
            var dto = new CreateCourseDto { Title = "Test Course", Type = "Grammar" };
            var result = await _service.CreateCourseAsync(dto);
            Assert.NotNull(result);
            Assert.Equal("Test Course", result.Title);
        }
    }
}
