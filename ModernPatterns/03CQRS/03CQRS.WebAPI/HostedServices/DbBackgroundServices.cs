
using _03CQRS.Application.Queues;
using _03CQRS.Infrastructure.Context;

namespace _03CQRS.WebAPI.HostedServices;

public sealed class DbBackgroundServices(
    IDbQueue dbQueu,
    IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var job in dbQueu.GetChannel().Reader.ReadAllAsync(stoppingToken))
        {
            using var scoped = serviceScopeFactory.CreateScope();
            var srv = scoped.ServiceProvider;
            var dbContext = srv.GetRequiredService<ReadDbContext>();

            dbContext.Add(job);
            await dbContext.SaveChangesAsync(stoppingToken);
            Console.WriteLine("I wrote product to read database");
            await Task.Delay(5000, stoppingToken);
        }
    }
}
