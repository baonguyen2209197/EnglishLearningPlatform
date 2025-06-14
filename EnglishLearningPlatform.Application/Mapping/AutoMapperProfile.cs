using AutoMapper;
using EnglishLearningPlatform.Domain.Entities;
using EnglishLearningPlatform.Application.DTOs;

namespace EnglishLearningPlatform.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CreateCourseDto, Course>();
        }
    }
}
