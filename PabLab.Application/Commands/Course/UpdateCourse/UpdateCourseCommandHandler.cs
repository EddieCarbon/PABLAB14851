using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ProductsApp.Application.Commands.Products.AddProduct;
using ProductsApp.Domain.Abstractions;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Exceptions;

namespace ProductsApp.Application.Commands.Products.UpdateProduct;

internal class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCourseCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
            throw new ProductNotFoundException(request.Id);

        if (product.Name != request.Name)
        {
            bool isAlreadyExist = await _productRepository.IsAlreadyExistAsync(request.Name, cancellationToken);
            if (isAlreadyExist)
                throw new ProductAlreadyExistsException(request.Name);
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Description = request.Description;

        _productRepository.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
