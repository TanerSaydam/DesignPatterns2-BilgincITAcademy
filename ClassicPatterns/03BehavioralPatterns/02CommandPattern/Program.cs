Console.WriteLine("Command Pattern");

var createCommand = new ProductCreateCommand();
createCommand.Handle();

Console.ReadLine();

//Bunun yerine metotlar ayrı classlara dönüştürülmeli
//interface IProductService
//{
//    void Create();
//    void Update();
//    void Delete();
//}

//class ProductService : IProductService
//{
//    public void Create() { }
//    public void Update() { }
//    public void Delete() { }
//}