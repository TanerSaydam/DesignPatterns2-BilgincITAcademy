using Mapster;

Console.WriteLine("Prototype Pattern");

Product product1 = new("Domates", 100, 10);
Product product2 = product1.Adapt<Product>(); //(Product)product1.Clone();
//product1.Adapt<Product>(); //create
//product1.Adapt(product2); //update
product2.Name = "Salatalık";

Console.ReadLine();

class Product : ICloneable
{
    public Product(string name, decimal price, int stock)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Price = price;
        Stock = stock;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public object Clone()
    {
        return new Product(Name, Price, Stock);
    }
}