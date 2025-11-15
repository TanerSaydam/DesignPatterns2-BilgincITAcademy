using _03CQRS.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace _03CQRS.WebAPI.Context;

public sealed class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
