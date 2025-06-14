using System;
using System.Collections.Generic;

namespace EnglishLearningPlatform.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public CourseType Type { get; set; } // Grammar, Vocabulary, etc.
        public ICollection<Lesson> Lessons { get; set; }
    }

    public enum CourseType
    {
        Grammar,
        Vocabulary,
        Listening,
        Speaking,
        Reading
    }

    public class Lesson
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
