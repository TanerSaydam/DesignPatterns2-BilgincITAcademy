using _04OptionsPattern.Options;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<List<UserOptions>>(builder.Configuration.GetSection("Users"));
builder.Services.Configure<List<string>>(builder.Configuration.GetSection("Names"));

builder.Services.ConfigureOptions<JwtSetupOptions>();
builder.Services.AddAuthentication().AddJwtBearer();

var app = builder.Build();

//var scoped = app.Services.CreateScope();
//var jwtOptions = scoped.ServiceProvider.GetRequiredService<IOptions<JwtOptions>>();

app.MapGet("/jwt-options", (IOptions<JwtOptions> options) =>
{
    return Results.Ok(options.Value);
});

app.MapGet("/user-options", (IOptions<List<UserOptions>> options) =>
{
    return Results.Ok(options.Value);
});

app.MapGet("/names", (IOptionsMonitor<List<string>> options) =>
{
    return Results.Ok(options.CurrentValue);
});

app.Run();
