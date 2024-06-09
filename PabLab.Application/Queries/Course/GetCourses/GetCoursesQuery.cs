using MediatR;
using ProductsApp.Application.Dtos;

namespace ProductsApp.Application.Queries.Products.GetProducts;

public record GetCoursesQuery() : IRequest<ProductListDto>; 
