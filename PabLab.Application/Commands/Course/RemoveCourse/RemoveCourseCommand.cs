using MediatR;

namespace ProductsApp.Application.Commands.Products.RemoveProduct;

public record RemoveCourseCommand(int Id) : IRequest;
