using FluentValidation;
using PabLab.Application.Commands.Course.UpdateCourse;

namespace PabLab.Application.Commands.Student.UpdateStudent;

public class UpdateEnrollmentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateEnrollmentCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required.")
            .MinimumLength(3).WithMessage("FirstName cannot be shorter the 3 character.")
            .MaximumLength(200).WithMessage("FirstName cannot be longer the 200 character.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required.")
            .MinimumLength(3).WithMessage("LastName cannot be shorter the 3 character.")
            .MaximumLength(200).WithMessage("LastName cannot be longer the 200 character.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth is required.");
    }
}
