using _03CQRS.WebAPI.Context;
using _03CQRS.WebAPI.Dtos;
using _03CQRS.WebAPI.Models;
using _03CQRS.WebAPI.Queues;
using Carter;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace _03CQRS.WebAPI.Modules;

public sealed class ProductModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder group)
    {
        var app = group.MapGroup("products").WithTags("Products");

        app.MapPost(string.Empty, async (
            CreateProductDto request,
            WriteDbContext dbContext,
            DbQueue dbQueue,
            CancellationToken cancellationToken) =>
        {
            var product = request.Adapt<Product>();
            dbContext.Add(product);
            await dbContext.SaveChangesAsync(cancellationToken);

            await dbQueue._channel.Writer.WriteAsync(product);

            return Results.NoContent();
        });

        app.MapGet(string.Empty, async (
            ReadDbContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var products = await dbContext.Products.OrderBy(p => p.Name).ToListAsync(cancellationToken);

            return products;
        });
    }
}
