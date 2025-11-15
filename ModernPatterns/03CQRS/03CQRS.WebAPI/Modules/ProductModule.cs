using _03CQRS.Application.Products;
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
            ProductCreate productCreate,
            CancellationToken cancellationToken) =>
        {
            await productCreate.Handle(request, cancellationToken);
            return Results.NoContent();
        });

        app.MapGet(string.Empty, async (
            ProductGetAll productGetAll,
            CancellationToken cancellationToken) =>
        {
            var products = await productGetAll.Handle(cancellationToken);
            return products;
        });
    }
}