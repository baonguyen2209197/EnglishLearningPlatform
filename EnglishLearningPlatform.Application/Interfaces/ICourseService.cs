using EnglishLearningPlatform.Application.DTOs;

namespace EnglishLearningPlatform.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseByIdAsync(Guid id);
        Task<CourseDto> CreateCourseAsync(CreateCourseDto dto);
        // ...Update, Delete, etc.
    }
}
