using MediatR;
using ProductsApp.Application.Dtos;

namespace ProductsApp.Application.Queries.Products.GetProductByName;

public record GetCourseByNameQuery(string Name) : IRequest<ProductDetailDto>;

