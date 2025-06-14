using EnglishLearningPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EnglishLearningPlatform.Infrastructure.Data;

namespace EnglishLearningPlatform.Infrastructure.Repositories
{
    public class CourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync() => await _context.Courses.ToListAsync();
        public async Task<Course?> GetByIdAsync(Guid id) => await _context.Courses.FindAsync(id);
        public async Task AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }
        // ...Update, Delete, etc.
    }
}
