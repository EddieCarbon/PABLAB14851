using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ProductsApp.Domain.Abstractions;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Exceptions;

namespace ProductsApp.Application.Commands.Products.AddProduct;

internal class AddCourseCommandHandler : IRequestHandler<AddProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCourseCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _productRepository.IsAlreadyExistAsync(request.Name, cancellationToken);
        if (isAlreadyExist) 
            throw new ProductAlreadyExistsException(request.Name);

        var newProduct = new Product()
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description
        };

        _productRepository.Add(newProduct);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
