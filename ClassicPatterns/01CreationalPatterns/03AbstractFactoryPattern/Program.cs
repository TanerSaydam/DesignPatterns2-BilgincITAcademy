using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Abstract Factory Pattern");

//Kullanım
#region Gerçek Hayat
var furniture1 = FurnitureFactoryProvider.Create("classic");
var chair1 = furniture1.CreateChair();
var chair2 = furniture1.CreateChair();

var furniture2 = FurnitureFactoryProvider.Create("modern");
var table = furniture2.CreateTable();
#endregion

ServiceCollection services = new();
services.AddTransient<IRepository, MSSqlRepository>();
services.AddTransient<IRepository, MSSqlRepository>();
services.AddTransient<IUnitOfWork, MSSQLUnitOfWork>();
services.AddTransient<IService, Service>();

var srv = services.BuildServiceProvider();
var myService = srv.GetRequiredService<IService>();

myService.Add();

Console.ReadLine();

//Hazırlık
#region Gerçek Hayat
interface IChair;
interface ITable;

class ClassicTable : ITable;

class ModernTable : ITable;

class ClassicChair : IChair;
class ModernChair : IChair;

interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}
class ClassicFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ClassicChair();

    public ITable CreateTable() => new ClassicTable();
}

class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ModernChair();

    public ITable CreateTable() => new ModernTable();
}

class FurnitureFactoryProvider
{
    public static IFurnitureFactory Create(string type)
    {
        switch (type)
        {
            case "modern": return new ModernFurnitureFactory();
            case "classic": return new ClassicFurnitureFactory();
            default: throw new ArgumentException("Invalid furniture type!");
        }
    }
}
#endregion

//Repository Pattern
//Unit Of Work Pattern
//Service Pattern

interface IRepository
{
    void Create();
}

interface IUnitOfWork
{
    void SaveChanges();
}

interface IService
{
    void Add();
}

class MSSqlRepository : IRepository
{
    public void Create()
    {
        //MSSQl DB Create
    }
}

class MongoDbRepository : IRepository
{
    public void Create()
    {
        //MSSQl DB Create
    }
}

class PostgreSqlRepository : IRepository
{
    public void Create()
    {
        //MSSQl DB Create
    }
}

class MSSQLUnitOfWork : IUnitOfWork
{
    public void SaveChanges()
    {
        //MSSQL Save Changes
    }
}

class MongoDbUnitOfWork : IUnitOfWork
{
    public void SaveChanges()
    {
        //MSSQL Save Changes
    }
}

class PostgreSqlUnitOfWork : IUnitOfWork
{
    public void SaveChanges()
    {
        //MSSQL Save Changes
    }
}

class Service(
    IRepository repository,
    IUnitOfWork unitOfWork) : IService //primary constructor
{
    //private readonly IRepository _repository;
    //private readonly IUnitOfWork _unitOfWork;
    //public Service(
    //    IRepository repository,
    //    IUnitOfWork unitOfWork)
    //{
    //    _repository = repository;
    //    _unitOfWork = unitOfWork;
    //}
    public void Add()
    {
        Console.WriteLine("Hello world!");
        repository.Create();
        unitOfWork.SaveChanges();
    }
}