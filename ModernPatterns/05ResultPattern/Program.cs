using _05ResultPattern;
using _05ResultPattern.Dtos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<ProductService>();

builder.Services.AddExceptionHandler<ExceptionHandler>().AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.MapPost("/create", (CreateProductDto request, ProductService productService) =>
{
    var res = productService.Create(request);
    return res;
});

app.MapGet("/get/{id}", (int id, ProductService productService) =>
{
    var res = productService.GetById(id);
    return res;
});

app.MapGet("/exception", () =>
{
    throw new Exception();
});

app.Run();

public class Result<T>
{
    private Result()
    { }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }

    public static Result<T> Succeed(T? data)
    {
        return new Result<T> { Data = data };
    }

    public static Result<T> Failed(string errorMessage)
    {
        return new Result<T> { ErrorMessage = errorMessage };
    }

    public static implicit operator Result<T>(T? data)
    {
        return new Result<T> { Data = data };
    }
}
