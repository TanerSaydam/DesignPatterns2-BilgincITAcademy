using _03CQRS.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace _03CQRS.Infrastructure.Context;

public sealed class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}