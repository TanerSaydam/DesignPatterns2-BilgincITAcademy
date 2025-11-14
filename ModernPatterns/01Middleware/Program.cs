using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.Use((context, next) =>
{
    //context kontrol
    return next(context);
});

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

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
