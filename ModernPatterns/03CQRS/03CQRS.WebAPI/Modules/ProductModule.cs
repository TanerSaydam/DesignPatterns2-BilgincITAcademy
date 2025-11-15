using _03CQRS.Application.Services;
using _03CQRS.Domain.Products.Dtos;
using Carter;

namespace _03CQRS.WebAPI.Modules;

public sealed class ProductModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder group)
    {
        var app = group.MapGroup("products").WithTags("Products");

        app.MapPost(string.Empty, async (
            CreateProductDto request,
            ProductService productService,
            CancellationToken cancellationToken) =>
        {
            await productService.Ceate(request, cancellationToken);
            return Results.NoContent();
        });

        app.MapGet(string.Empty, async (
            ProductService productService,
            CancellationToken cancellationToken) =>
        {
            var products = await productService.GetAll(cancellationToken);
            return products;
        });
    }
}