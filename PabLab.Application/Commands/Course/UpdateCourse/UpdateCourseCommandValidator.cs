using FluentValidation;
using FluentValidation.Results;
using ProductsApp.Application.Commands.Products.AddProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Commands.Products.UpdateProduct;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
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
