using MediatR;
using ProductsApp.Application.Dtos;

namespace ProductsApp.Application.Queries.Products.GetProductById;

public record GetCourseByIdQuery(int Id) : IRequest<ProductDetailDto>;
