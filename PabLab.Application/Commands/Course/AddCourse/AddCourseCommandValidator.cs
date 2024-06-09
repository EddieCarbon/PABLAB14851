using FluentValidation;
using ProductsApp.Domain.Abstractions;

namespace ProductsApp.Application.Commands.Products.AddProduct;

public class AddCourseCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddCourseCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name cannot be shorter the 3 character.")
            .MaximumLength(200).WithMessage("Name cannot be longer the 200 character.");
            
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price cannot be less than 0.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(2000).WithMessage("Description cannot be longer the 2000 character.");
    }
}
