using _03CQRS.Application.Queues;
using _03CQRS.Domain.Products;
using _03CQRS.Domain.Products.Dtos;
using Mapster;

namespace _03CQRS.Application.Services;

public sealed class ProductService(
    IDbQueue dbQueue,
    IProductRepository productRepository)
{
    public async Task Ceate(CreateProductDto request, CancellationToken cancellationToken)
    {
        //iş kuralları        
        var product = request.Adapt<Product>();
        await productRepository.CreateAsync(product);
        await dbQueue.GetChannel().Writer.WriteAsync(product);
    }

    public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
    {
        //iş kuralları
        return await productRepository.GetAllAsync(cancellationToken);
    }
}
