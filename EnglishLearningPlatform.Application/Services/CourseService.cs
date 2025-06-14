using EnglishLearningPlatform.Application.DTOs;
using EnglishLearningPlatform.Application.Interfaces;
using EnglishLearningPlatform.Domain.Entities;
using EnglishLearningPlatform.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EnglishLearningPlatform.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CourseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetCourseByIdAsync(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> CreateCourseAsync(CreateCourseDto dto)
        {
            var course = _mapper.Map<Course>(dto);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return _mapper.Map<CourseDto>(course);
        }
    }
}
