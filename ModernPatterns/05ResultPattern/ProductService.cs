using _05ResultPattern.Dtos;
using _05ResultPattern.Models;

namespace _05ResultPattern;

public sealed class ProductService
{
    public Result<string> Create(CreateProductDto request)
    {
        //db işlemleri

        //return Result<string>.Succeed("Create is successful");
        return "Create is successful";
    }

    public Result<Product> GetById(int id)
    {
        //return Result<Product>.Succeed(new Product());
        return new Product();
    }
}
