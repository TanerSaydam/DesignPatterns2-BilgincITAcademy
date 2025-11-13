Console.WriteLine("Builder Pattern");

#region Gerçek Hayat Örneği
//House house = new(windowCount: 3, doorCount: 1, haveGarden: false, havePool: true);

IHouseBuilder builder = new HouseBuilder();
var house1 = builder
    .WindowCount(3)
    .DoorCount(2)
    .Build();

var house2 = builder
    .WindowCount(4)
    .DoorCount(1)
    .HaveGarden()
    .Build();

var house3 = builder
    .WindowCount(12)
    .DoorCount(4)
    .HaveGarden()
    .HavePool()
    .Build();
#endregion

Console.ReadLine();

#region Gerçek Hayat Örneği
class House
{
    public House(int windowCount, int doorCount, bool haveGarden, bool havePool)
    {
        WindowCount = windowCount;
        DoorCount = doorCount;
        HaveGarden = haveGarden;
        HavePool = havePool;
    }

    public int WindowCount { get; set; }
    public int DoorCount { get; set; }
    public bool HaveGarden { get; set; }
    public bool HavePool { get; set; }
}

interface IHouseBuilder
{
    IHouseBuilder WindowCount(int windowCount);
    IHouseBuilder DoorCount(int doorCount);
    IHouseBuilder HaveGarden();
    IHouseBuilder HavePool();
    House Build();
}

class HouseBuilder : IHouseBuilder
{
    int _windowCount;
    int _doorCount;
    bool _haveGarden;
    bool _havePool;
    public IHouseBuilder WindowCount(int windowCount)
    {
        _windowCount = windowCount;
        return this;
    }

    public IHouseBuilder DoorCount(int doorCount)
    {
        _doorCount = doorCount;
        return this;
    }

    public IHouseBuilder HaveGarden()
    {
        _haveGarden = true;
        return this;
    }

    public IHouseBuilder HavePool()
    {
        _havePool = true;
        return this;
    }

    public House Build()
    {
        return new House(
            windowCount: _windowCount,
            doorCount: _doorCount,
            haveGarden: _haveGarden,
            havePool: _havePool);
    }
}
#endregion