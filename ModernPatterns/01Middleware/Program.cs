using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository1>();

var app = builder.Build();

app.MapOpenApi();

app.Use(async (context, next) =>
{
    //context kontrol
    await next(context);
});

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    //context kontrol
    await next(context);
});

app.MapControllers();


app.Run();

class MyValidation : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Metodun sonunda");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Metodun baþýnda");
    }
}


public interface IProductRepository;

public class ProductRepository1 : IProductRepository;
public class ProductRepository2 : IProductRepository;