namespace _03CQRS.Domain.Products;

public interface IProductRepository
{
    Task CreateAsync(Product product, CancellationToken cancellationToken = default);

    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}

public interface IWriteProductRepository
{
    Task CreateAsync(Product product, CancellationToken cancellationToken = default);
}


public interface IReadProductRepository
{
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}
