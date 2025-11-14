Console.WriteLine("Composite Pattern");

var menu = new MenuGroup("Ana Menü");
var haberler = new MenuGroup("Haberler");
haberler.Add(new MenuItem("Yeni Haberler"));
haberler.Add(new MenuItem("Eski Haberler"));

var iletisim = new MenuGroup("İletişim");

menu.Add(haberler);
menu.Add(iletisim);

menu.Display(0);

Console.ReadLine();

interface IMenuComponent
{
    string Name { get; }
    void Display(int dept);
}

class MenuItem : IMenuComponent
{
    public string Name { get; }
    public MenuItem(string name)
    {
        Name = name;
    }
    public void Display(int dept)
    {
        Console.WriteLine(new string('-', dept) + Name);
    }
}

class MenuGroup : IMenuComponent
{
    public string Name { get; }
    private readonly List<IMenuComponent> _children = new();
    public MenuGroup(string name)
    {
        Name = name;
    }

    public void Add(IMenuComponent item) => _children.Add(item);
    public void Remove(IMenuComponent item) => _children.Remove(item);
    public void Display(int dept)
    {
        Console.WriteLine(new string('-', dept) + Name);
        foreach (IMenuComponent item in _children)
        {
            item.Display(dept + 2);
        }
    }
}

//class Menu
//{
//    public Guid Id { get; set;  }
//    public string Name { get; set; } = default!;
//    public Guid? MainMenuId { get; set; }
//}