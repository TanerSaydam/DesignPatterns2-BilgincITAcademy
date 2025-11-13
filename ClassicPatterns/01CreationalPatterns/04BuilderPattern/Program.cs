using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;

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

#region Proje Örneği
new MailService()
    .WithFrom("tanersaydam@gmail.com")
    .WithTo("info@test.com")
    .WithSubject("Test")
    .WithBody("This is a test message")
    .Send();

new MailService()
    .WithFrom("tanersaydam@gmail.com")
    .WithTo("info@test2.com")
    .WithSubject("Test")
    .Send();

new MailService()
    .WithFrom("tanersaydam@gmail.com")
    .WithTo("info@test2.com")
    .WithSubject("Test")
    .WithBody("This is a test message")
    .WithAttachments(new List<string>() { "Hello", "World" })
    .Send();
#endregion

ServiceCollection services = new();
services
    .AddFluentEmail("info@test.com")
    .AddSmtpSender("localhost", 25);

var srv = services.BuildServiceProvider();
var fluentEmail = srv.GetRequiredService<IFluentEmail>();

fluentEmail
    .To("tanersaydam@gmail.com")
    .Subject("Test")
    .Body("<h1>Hello world!</h1>", true)
    .Send();

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

#region Proje Örneği
class MailService
{
    public MailService()
    {
    }
    public MailService(string from, string to, string subject, string body, List<string> attachments)
    {
        From = from;
        To = to;
        Subject = subject;
        Body = body;
        Attachments = attachments;
    }

    public string From { get; set; } = default!;
    public string To { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public string Body { get; set; } = default!;
    public List<string> Attachments { get; set; } = new();

    public MailService WithFrom(string from)
    {
        From = from;
        return this;
    }

    public MailService WithTo(string to)
    {
        To = to;
        return this;
    }

    public MailService WithSubject(string subject)
    {
        Subject = subject;
        return this;
    }

    public MailService WithBody(string body)
    {
        Body = body;
        return this;
    }

    public MailService WithAttachments(List<string> attachments)
    {
        Attachments = attachments;
        return this;
    }

    public void Send()
    {

    }
}
#endregion