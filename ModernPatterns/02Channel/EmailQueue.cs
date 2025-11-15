using System.Threading.Channels;

namespace _02Channel;

public class EmailQueue
{
    public readonly Channel<EmailDto> _channel;

    public EmailQueue()
    {
        _channel = Channel.CreateBounded<EmailDto>(
            new BoundedChannelOptions(1)
            {
                SingleReader = true,
                SingleWriter = true
            });
    }
}
