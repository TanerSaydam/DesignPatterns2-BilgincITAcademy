using Microsoft.AspNetCore.Mvc;

namespace _01Middleware.Controllers;

[ApiController]
[Route("api/products")]
public sealed class ProductsController : ControllerBase
{
    [HttpGet]
    [MyValidation]
    public IActionResult Get(string name)
    {
        //buesiness rules
        return Ok();
    }
}
