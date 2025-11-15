using _03CQRS.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace _03CQRS.Infrastructure.Context;

public sealed class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
