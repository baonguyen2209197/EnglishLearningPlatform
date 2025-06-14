using EnglishLearningPlatform.Application.DTOs;
using FluentValidation;

namespace EnglishLearningPlatform.Application.Validators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
