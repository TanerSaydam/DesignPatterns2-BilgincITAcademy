using _03CQRS.Application.Products;
using _03CQRS.Application.Queues;
using _03CQRS.Infrastructure.Context;
using _03CQRS.Infrastructure.Queues;
using _03CQRS.Infrastructure.Repositories;
using _03CQRS.WebAPI.HostedServices;
using Carter;
using Microsoft.EntityFrameworkCore;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WriteDbContext>(opt => opt.UseInMemoryDatabase("MyDb1"));
builder.Services.AddDbContext<ReadDbContext>(opt => opt.UseInMemoryDatabase("MyDb2"));

builder.Services.AddHostedService<DbBackgroundServices>();
builder.Services.AddSingleton<IDbQueue, DbQueue>();

//builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.Scan(x => x
 .FromAssemblies(typeof(ProductRepository).Assembly)
 .AddClasses(publicOnly: true)
 .UsingRegistrationStrategy(RegistrationStrategy.Skip)
 .AsMatchingInterface()
 .WithTransientLifetime()
 );

builder.Services.AddMediatR(cfr =>
{
    cfr.RegisterServicesFromAssembly(typeof(ProductCreateCommand).Assembly);
});

builder.Services.AddCarter();
builder.Services.AddCors();

// AddResponseCompression

builder.Services.AddResponseCompression(x =>
{
    x.EnableForHttps = true;
});

var app = builder.Build();

app.UseCors(x => x
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin()
.SetPreflightMaxAge(TimeSpan.FromMinutes(10))
);

app.UseResponseCompression();

app.MapCarter();

app.Run();
