using Polly;
using Polly.Registry;
using Polly.Retry;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConsulDiscoveryClient();
builder.Services.AddHttpClient();

builder.Services.AddResiliencePipeline("my-pipeline", builder =>
{
    builder
        .AddRetry(new RetryStrategyOptions()
        {
            MaxRetryAttempts = 3,
            Delay = TimeSpan.FromSeconds(10),
        })
        .AddTimeout(TimeSpan.FromSeconds(60));
});

var app = builder.Build();

app.MapGet("/", async (
    IDiscoveryClient discoveryClient,
    ResiliencePipelineProvider<string> resiliencePipelineProvider,
    HttpClient httpClient) =>
{
    var pipeline = resiliencePipelineProvider.GetPipeline("my-pipeline");

    var services = await pipeline.Execute(async () =>
    {
        return await discoveryClient.GetInstancesAsync("ProductWebAPI", default);
    });

    var url = services.First().Uri; // localhost:6500/


    var res = await httpClient.GetFromJsonAsync<List<string>>(url + "products");

    return res;
});

app.Run();
