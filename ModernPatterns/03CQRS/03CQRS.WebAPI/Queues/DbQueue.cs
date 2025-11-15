using _03CQRS.WebAPI.Models;
using System.Threading.Channels;

namespace _03CQRS.WebAPI.Queues;

public sealed class DbQueue
{
    public readonly Channel<Product> _channel;
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
