namespace EnglishLearningPlatform.Application.DTOs
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }

    public class CreateCourseDto
    {
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
