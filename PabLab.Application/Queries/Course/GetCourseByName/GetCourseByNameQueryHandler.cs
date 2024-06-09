using AutoMapper;
using MediatR;
using ProductsApp.Application.Dtos;
using ProductsApp.Application.Queries.Products.GetProductById;
using ProductsApp.Domain.Abstractions;

namespace ProductsApp.Application.Queries.Products.GetProductByName;

internal class GetCourseByNameQueryHandler : IRequestHandler<GetCourseByNameQuery, ProductDetailDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetCourseByNameQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDetailDto> Handle(GetCourseByNameQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByNameAsync(request.Name, cancellationToken);

        var productDto = _mapper.Map<ProductDetailDto>(product);

        return productDto;
    }
}
