using MediatR;
using ProductsApp.Application.Commands.Products.UpdateProduct;
using ProductsApp.Domain.Abstractions;
using ProductsApp.Domain.Exceptions;

namespace ProductsApp.Application.Commands.Products.RemoveProduct;

internal class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCourseCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
            throw new ProductNotFoundException(request.Id);

        _productRepository.Delete(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
