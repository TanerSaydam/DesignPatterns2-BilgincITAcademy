using Carter;

namespace _01Middleware.Modules;

public class ProductModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder group)
    {
        var app = group.MapGroup("api/products").RequireAuthorization();

        app.MapGet("", () => { });
    }
}
