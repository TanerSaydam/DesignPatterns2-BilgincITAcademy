using _03CQRS.Application.Products;
using Carter;
using MediatR;

namespace _03CQRS.WebAPI.Modules;

public sealed class ProductModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder group)
    {
        var app = group.MapGroup("products").WithTags("Products");

        app.MapPost(string.Empty, async (
            ProductCreateCommand request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            await sender.Send(request, cancellationToken);
            return Results.NoContent();
        });

        app.MapGet(string.Empty, async (
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var products = await sender.Send(new ProductGetAllQuery(), cancellationToken);
            return products;
        });
    }
}