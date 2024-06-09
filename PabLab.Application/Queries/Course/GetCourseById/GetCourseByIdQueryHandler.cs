using AutoMapper;
using MediatR;
using ProductsApp.Application.Dtos;
using ProductsApp.Domain.Abstractions;

namespace ProductsApp.Application.Queries.Products.GetProductById;

internal class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, ProductDetailDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetCourseByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDetailDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

        var productDto = _mapper.Map<ProductDetailDto>(product);

        return productDto;
    }
}
