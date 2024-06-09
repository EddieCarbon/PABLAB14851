using FluentValidation;
using ProductsApp.Application.Identity.Classes;
using ProductsApp.Application.Identity.Enums;

namespace ProductsApp.Application.Commands.Identity.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Password is required.");
        RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Password is required.");
        RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Confirm password is required.");
        RuleFor(x => x).Must(x => PasswordManager.CheckPasswordStrength(x.NewPassword) == PasswordScore.VeryStrong).WithMessage("New password is not very strong.").WithName("NewPassword");
    }
}
