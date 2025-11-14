using Microsoft.AspNetCore.Mvc;

namespace _01Middleware.Controllers;

[ApiController]
[Route("api/products")]
public sealed class ProductsController(
    IProductRepository productRepository) : ControllerBase
{
    [HttpGet]
    [MyValidation]
    public IActionResult Get(string name)
    {
        //buesiness rules
        return Ok();
    }

    [HttpPost]
    [MyValidation]
    public IActionResult Create(ProductDto request)
    {
        //buesiness rules
        return Ok();
    }
}

public record ProductDto(
    string Name,
    decimal Price);