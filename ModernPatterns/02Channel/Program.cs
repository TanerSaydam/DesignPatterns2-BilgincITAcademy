using _02Channel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<EmailQueue>();
builder.Services.AddScoped<TestScoped>();
builder.Services.AddHostedService<EmailBackgroundService>();

var app = builder.Build();

app.MapPost("send-email", async (EmailDto request, EmailQueue emailQueue, CancellationToken cancellationToken) =>
{
    await emailQueue._channel.Writer.WriteAsync(request, cancellationToken);
    return Results.Ok();
});

app.Run();

public record EmailDto(
    string To,
    string Subject);

public class TestScoped { }