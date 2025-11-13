Console.WriteLine("Abstract Factory Pattern");

//Kullanım
var furniture1 = FurnitureFactoryProvider.Create("classic");
var chair1 = furniture1.CreateChair();
var chair2 = furniture1.CreateChair();

var furniture2 = FurnitureFactoryProvider.Create("modern");
var table = furniture2.CreateTable();

Console.ReadLine();

//Hazırlık
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

