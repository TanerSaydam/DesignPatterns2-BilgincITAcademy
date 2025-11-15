using _03CQRS.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace _03CQRS.WebAPI.Context;

public sealed class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}