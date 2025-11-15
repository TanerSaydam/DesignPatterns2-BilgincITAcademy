using _03CQRS.Domain.Products;
using MediatR;

namespace _03CQRS.Application.Products;

public sealed record ProductGetAllQuery() : IRequest<List<Product>>;
internal sealed class ProductGetAllQueryHandler(
    IProductRepository productRepository) : IRequestHandler<ProductGetAllQuery, List<Product>>
{
    public async Task<List<Product>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
    {
        var res = await productRepository.GetAllAsync(cancellationToken);
        return res;
    }
}
