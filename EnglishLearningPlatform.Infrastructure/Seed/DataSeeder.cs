using System.Security.Cryptography;
using EnglishLearningPlatform.Domain.Entities;
using EnglishLearningPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EnglishLearningPlatform.Infrastructure.Seed
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Courses.Any())
            {
                var grammar = new Course { Id = Guid.NewGuid(), Title = "Basic Grammar", Type = CourseType.Grammar };
                var vocab = new Course { Id = Guid.NewGuid(), Title = "Everyday Vocabulary", Type = CourseType.Vocabulary };
                context.Courses.AddRange(grammar, vocab);
                context.Lessons.AddRange(
                    new Lesson { Id = Guid.NewGuid(), Title = "Nouns", Content = "Lesson on nouns", Course = grammar },
                    new Lesson { Id = Guid.NewGuid(), Title = "Verbs", Content = "Lesson on verbs", Course = grammar },
                    new Lesson { Id = Guid.NewGuid(), Title = "Daily Words", Content = "Lesson on daily words", Course = vocab }
                );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.Add(new User { Id = Guid.NewGuid(), Email = "admin@elp.com", Name = "Admin", Role = UserRole.Admin, PasswordHash = HashPassword("admin123") });
                context.SaveChanges();
            }
        }
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
