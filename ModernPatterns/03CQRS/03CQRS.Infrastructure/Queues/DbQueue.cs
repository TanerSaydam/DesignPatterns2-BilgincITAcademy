using _03CQRS.Application.Queues;
using _03CQRS.Domain.Products;
using System.Threading.Channels;

namespace _03CQRS.Infrastructure.Queues;

public sealed class DbQueue : IDbQueue
{
    private readonly Channel<Product> _channel;
    public Channel<Product> GetChannel() => _channel;

    public DbQueue()
    {
        _channel = Channel.CreateBounded<Product>(
            new BoundedChannelOptions(1)
            {
                SingleReader = true,
                SingleWriter = true
            });
    }
}