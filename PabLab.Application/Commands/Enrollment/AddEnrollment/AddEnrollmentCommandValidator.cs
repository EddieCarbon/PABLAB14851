using FluentValidation;

namespace PabLab.Application.Commands.Enrollment.AddEnrollment;

public class AddEnrollmentCommandValidator : AbstractValidator<AddEnrollmentCommand>
{
    public AddEnrollmentCommandValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("StudentId is required.");
            
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("CourseId is required.");
    }
}
