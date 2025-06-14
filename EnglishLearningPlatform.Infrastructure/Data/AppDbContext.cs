using EnglishLearningPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnglishLearningPlatform.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API config here
        }
    }
}
