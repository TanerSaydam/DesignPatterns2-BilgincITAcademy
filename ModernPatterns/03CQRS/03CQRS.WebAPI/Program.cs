using _03CQRS.WebAPI.Context;
using _03CQRS.WebAPI.HostedServices;
using _03CQRS.WebAPI.Queues;
using Carter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WriteDbContext>(opt => opt.UseInMemoryDatabase("MyDb1"));
builder.Services.AddDbContext<ReadDbContext>(opt => opt.UseInMemoryDatabase("MyDb2"));

builder.Services.AddSingleton<DbQueue>();
builder.Services.AddHostedService<DbBackgroundServices>();

builder.Services.AddCarter();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin()
.SetPreflightMaxAge(TimeSpan.FromMinutes(10))
);

app.MapCarter();

app.Run();
