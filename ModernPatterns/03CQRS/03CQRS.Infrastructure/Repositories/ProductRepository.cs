using _03CQRS.Domain.Products;
using _03CQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace _03CQRS.Infrastructure.Repositories;

public sealed class ProductRepository(
    WriteDbContext writeDbContext,
    ReadDbContext readDbContext) : IProductRepository
{
    public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        writeDbContext.Add(product);
        await writeDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await readDbContext.Products.OrderBy(p => p.Name).ToListAsync(cancellationToken);
    }
}
