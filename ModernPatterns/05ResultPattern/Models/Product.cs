namespace _05ResultPattern.Models;

public sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
}
