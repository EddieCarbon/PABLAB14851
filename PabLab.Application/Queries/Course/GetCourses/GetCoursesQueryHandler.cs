using AutoMapper;
using MediatR;
using ProductsApp.Application.Dtos;
using ProductsApp.Domain.Abstractions;

namespace ProductsApp.Application.Queries.Products.GetProducts;

internal class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, ProductListDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetCoursesQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductListDto> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);

        var productsDto = _mapper.Map<ProductListDto>(products);

        return productsDto;
    }
}
