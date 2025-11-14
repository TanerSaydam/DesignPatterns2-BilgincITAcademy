Console.WriteLine("Proxy Pattern");

ProductService productService = new(new ProductRepository());
productService.Create(new ProductDto("Bilgisayar", 5000));

Console.ReadLine();

record ProductDto(
    string Name,
    decimal Price);

class ProductRepository
{
    public void Create(ProductDto request)
    {
        //kayıt işlemi
    }
}

class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Create(ProductDto request)
    {
        //Loglama
        //Cachle
        //Validation check
        //Unique check

        //Business Rules
        _productRepository.Create(request);
    }
}
