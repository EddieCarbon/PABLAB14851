using FluentValidation;

namespace PabLab.Application.Commands.Student.AddStudent;

public class AddEnrollmentCommandValidator : AbstractValidator<AddStudentCommand>
{
    public AddEnrollmentCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required.")
            .MinimumLength(3).WithMessage("FirstName cannot be shorter the 3 character.")
            .MaximumLength(200).WithMessage("FirstName cannot be longer the 200 character.");
            
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("FirstName is required.")
            .MinimumLength(3).WithMessage("FirstName cannot be shorter the 3 character.")
            .MaximumLength(200).WithMessage("FirstName cannot be longer the 200 character.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.");
    }
}
