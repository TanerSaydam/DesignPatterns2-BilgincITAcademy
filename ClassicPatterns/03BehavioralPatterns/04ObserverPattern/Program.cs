Console.WriteLine("Observer Pattern");

var phone = new Phone();
var tv = new TV();
var wp = new WP();

var station = new WeaterStation();
station.TempChanged += phone.Update;
station.TempChanged += tv.Update;
//station.Subscribe(phone);
//station.Subscribe(tv);
//station.Subscribe(wp);

station.SetTemp(35);

//station.UnSubscribe(wp);
station.TempChanged -= tv.Update;

station.SetTemp(25);


Console.ReadLine();

interface IWeaterStation
{
    void SetTemp(decimal temp);
    //void Subscribe(IObserver observer);
    //void UnSubscribe(IObserver observer);
    decimal GetTemp();
    //void Notify();
}

interface IObserver
{
    void Update(IWeaterStation weaterStation);
}

class WeaterStation : IWeaterStation
{
    //private readonly HashSet<IObserver> _observers = new();
    private decimal _temp;

    public event Action<decimal>? TempChanged;

    public void SetTemp(decimal temp)
    {
        _temp = temp;
        Console.WriteLine("[Station] new temp is {0}", temp);
        TempChanged?.Invoke(temp);
        // Notify();
        Console.WriteLine("-------------");
    }
    public decimal GetTemp() => _temp;

    //public void Subscribe(IObserver observer)
    //{
    //    _observers.Add(observer);
    //}

    //public void Notify()
    //{
    //    foreach (var observer in _observers)
    //    {
    //        observer.Update(this);
    //    }
    //}

    //public void UnSubscribe(IObserver observer)
    //{
    //    _observers.Remove(observer);
    //}
}

class Phone : IObserver
{
    public void Update(IWeaterStation weaterStation)
    {
        Console.WriteLine("[Phone] temp is {0}", weaterStation.GetTemp());
    }

    public void Update(decimal temp)
    {
        Console.WriteLine("[Phone] temp is {0}", temp);
    }
}

class TV : IObserver
{
    public void Update(IWeaterStation weaterStation)
    {
        Console.WriteLine("[TV] temp is {0}", weaterStation.GetTemp());
    }

    public void Update(decimal temp)
    {
        Console.WriteLine("[TV] temp is {0}", temp);
    }
}

class WP : IObserver
{
    public void Update(IWeaterStation weaterStation)
    {
        Console.WriteLine("[WP] temp is {0}", weaterStation.GetTemp());
    }
}