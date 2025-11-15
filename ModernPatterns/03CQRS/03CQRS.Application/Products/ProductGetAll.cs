using _03CQRS.Domain.Products;

namespace _03CQRS.Application.Products;

public sealed class ProductGetAll(
    IProductRepository productRepository)
{
    public async Task<List<Product>> Handle(CancellationToken cancellationToken = default)
    {
        var res = await productRepository.GetAllAsync(cancellationToken);
        return res;
    }
}
