using _03CQRS.Application.Queues;
using _03CQRS.Domain.Products;
using _03CQRS.Domain.Products.Dtos;
using Mapster;

namespace _03CQRS.Application.Products;

public sealed class ProductCreate(
    IProductRepository productRepository,
    IDbQueue dbQueue)
{
    public async Task Handle(CreateProductDto request, CancellationToken cancellationToken = default)
    {
        //iş kuralları        
        var product = request.Adapt<Product>();
        await productRepository.CreateAsync(product);
        await dbQueue.GetChannel().Writer.WriteAsync(product);
    }
}
