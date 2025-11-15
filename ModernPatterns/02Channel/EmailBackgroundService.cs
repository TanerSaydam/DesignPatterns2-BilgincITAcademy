namespace _02Channel;

public class EmailBackgroundService(
    EmailQueue emailQueue,
    IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scoped = serviceScopeFactory.CreateScope();
        var srv = scoped.ServiceProvider;
        var testScoped = srv.GetRequiredService<TestScoped>();

        await foreach (var job in emailQueue._channel.Reader.ReadAllAsync(stoppingToken))
        {
            Console.WriteLine($"Sending email to {job.To} with subject {job.Subject}");
            await Task.Delay(500, stoppingToken);
        }
    }
}