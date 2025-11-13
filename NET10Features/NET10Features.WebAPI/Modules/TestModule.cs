using Carter;
using NET10Features.WebAPI.Context;
using System.ComponentModel.DataAnnotations;

namespace NET10Features.WebAPI.Modules;

public class TestModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder group)
    {
        var app = group.MapGroup("api").WithTags("Test1");

        app.MapGet("null-conditional", () =>
        {
            Test2 test2 = new();
            test2?.Number += 1;
            return Results.Ok();
        });

        app.MapGet("enhanced-form-validation", (
            [Required] string name, [EmailAddress] string email) =>
        {
            return Results.Ok();
        });

        app.MapGet("efcore-left-right-join", (ApplicationDbContext dbContext) =>
        {
            var res = dbContext.Products
            .LeftJoin(
                dbContext.Categories,
                t => t.CategoryId,
                t => t.Id,
                (product, category) => new { product, category })
            //.RightJoin(
            //    dbContext.Categories,
            //    t => t.CategoryId,
            //    t => t.Id,
            //    (product, category) => new { product, category })
            .Select(s => new
            {
                Id = s.product.Id,
                Name = s.product.Name,
                CategoryId = s.product.CategoryId,
                CategoryName = s.category == null ? "" : s.category.Name
            })
            .ToList();

            return res;
        });
    }
}
