using _03CQRS.Domain.Products;
using System.Threading.Channels;

namespace _03CQRS.Application.Queues;

public interface IDbQueue
{
    Channel<Product> GetChannel();
}