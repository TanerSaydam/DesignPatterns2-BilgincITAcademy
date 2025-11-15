using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConsulDiscoveryClient();

var app = builder.Build();

app.MapGet("/products", () => new List<string>() { "Domates", "Biber", "Patlýcan" });

app.Run();
