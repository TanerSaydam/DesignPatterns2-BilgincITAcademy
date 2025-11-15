namespace _03CQRS.WebAPI.Dtos;

public sealed record CreateProductDto(
    string Name,
    decimal Price);
