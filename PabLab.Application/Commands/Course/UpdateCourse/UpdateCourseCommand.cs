using MediatR;

namespace ProductsApp.Application.Commands.Products.UpdateProduct;

public class UpdateCourseCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}
