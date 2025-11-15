using _03CQRS.Application.Queues;
using _03CQRS.Domain.Products;
using Mapster;
using MediatR;

namespace _03CQRS.Application.Products;

public sealed record ProductCreateCommand(
    string Name,
    decimal Price) : IRequest;

internal sealed class ProductCreateCommandHandler(
    IProductRepository productRepository,
    IDbQueue dbQueue) : IRequestHandler<ProductCreateCommand>
{
    public async Task Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        //iş kuralları        
        var product = request.Adapt<Product>();
        await productRepository.CreateAsync(product);
        await dbQueue.GetChannel().Writer.WriteAsync(product);
    }
}