using System;
using System.Collections.Generic;

namespace EnglishLearningPlatform.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string PasswordHash { get; set; } // Thêm trường này để lưu hash password
        public ICollection<UserProgress> Progress { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User
    }

    public class UserProgress
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid LessonId { get; set; }
        public int Score { get; set; }
        public TimeSpan StudyTime { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
