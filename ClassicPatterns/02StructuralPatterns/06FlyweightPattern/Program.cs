using Microsoft.Extensions.Caching.Memory;

Console.WriteLine("Flyweight Pattern");

var forest = new Forest();
forest.PlaceTree(5, 10, "Çam", "Kahverengi", "kahverengi.jpg");
forest.PlaceTree(10, 15, "Çam", "Kahverengi", "kahverengi.jpg");
forest.PlaceTree(20, 15, "Çam", "Kırmızı", "kirmizi.jpg");
forest.PlaceTree(30, 45, "Kavak", "Kırmızı", "kirmizi.jpg");

forest.Draw();

Console.ReadLine();

class TreeType
{
    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }

    public string Name { get; set; }
    public string Color { get; set; }
    public string Texture { get; set; }

    public void Draw(int x, int y)
    {
        Console.WriteLine("Draw {0} at ({1}, {2}) with {3} color and {4} texture", Name, x, y, Color, Texture);
    }
}

class Tree
{
    public Tree(int x, int y, TreeType treeType)
    {
        X = x;
        Y = y;
        TreeType = treeType;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public TreeType TreeType { get; set; }

    public void Draw() => TreeType.Draw(X, Y);
}

class TreeFactory
{
    private static readonly Dictionary<string, TreeType> _cache = new();
    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}|{color}|{texture}";
        if (_cache.TryGetValue(key, out var type))
        {
            Console.WriteLine("--{0} added from cache", name);
            return type;
        }

        type = new TreeType(name, color, texture);
        _cache.Add(key, type);
        return type;
    }
}

class Forest
{
    public List<Tree> _trees = new();
    MemoryCache memoryCache = new(new MemoryCacheOptions());
    public void PlaceTree(int x, int y, string name, string color, string texture)
    {
        string key = $"{name}|{color}|{texture}";
        TreeType? treeType = (TreeType?)memoryCache.Get(key);
        if (treeType is null)
        {
            treeType = new TreeType(name, color, texture);
            memoryCache.Set(key, treeType);
        }
        else
        {
            Console.WriteLine("--{0} added from cache", name);
        }

        //var treeType = TreeFactory.GetTreeType(name, color, texture);
        var tree = new Tree(x, y, treeType);
        _trees.Add(tree);
    }

    public void Draw()
    {
        foreach (Tree tree in _trees)
        {
            tree.Draw();
        }
    }
}