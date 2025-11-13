using Carter;
using Microsoft.EntityFrameworkCore;
using NET10Features.WebAPI.Context;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Service registration
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseInMemoryDatabase("MyDb");
});

builder.Services.AddOpenApi();
builder.Services.AddCarter();

//Service registration

var app = builder.Build();

//Middleware

app.MapOpenApi();
app.MapScalarApiReference();

app.MapCarter();

//Middleware
app.Run();

#region Field-Backed Properties (field keyword)
class Test1
{
    public string Name
    {
        get
        {
            return field;
        }
        set
        {
            field = value ?? throw new ArgumentNullException(nameof(value));
        }
    } = default!;
}
#endregion

#region Extension Members
static class Extensions
{
    extension(string source)
    {
        public int WordCount()
        {
            return source.Length;
        }

        public bool IsEmpty => string.IsNullOrEmpty(source);
    }
}
#endregion

#region Null-Conditional
class Test2
{
    public int? Number { get; set; }
}
#endregion