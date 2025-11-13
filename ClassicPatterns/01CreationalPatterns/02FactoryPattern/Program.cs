using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Factory Pattern");

ServiceCollection services = new();
services.AddKeyedTransient<INotification, EmailNotification>(NotificationTypeEnum.Email);
services.AddKeyedTransient<INotification, SmsNotification>(NotificationTypeEnum.Sms);
services.AddKeyedTransient<INotification, WPNotification>(NotificationTypeEnum.WP);

var srv = services.BuildServiceProvider();

//INotification notification1 = NotificationFactory.Create(NotificationTypeEnum.Email); //old solution
INotification notification1 = srv.GetRequiredKeyedService<INotification>(NotificationTypeEnum.Email); //güncel solution
notification1.Send("Hello world");

INotification notification2 = srv.GetRequiredKeyedService<INotification>(NotificationTypeEnum.Sms);
notification2.Send("Hello world");

INotification notification3 = srv.GetRequiredKeyedService<INotification>(NotificationTypeEnum.WP);
notification2.Send("Hello world");

Console.ReadLine();

interface INotification
{
    void Send(string message);
}

class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}

class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}

class WPNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}

class NotificationFactory
{
    public static INotification Create(NotificationTypeEnum type)
    {
        switch (type)
        {
            case NotificationTypeEnum.Email: return new EmailNotification();
            case NotificationTypeEnum.Sms: return new SmsNotification();
            case NotificationTypeEnum.WP: return new WPNotification();

            default: throw new ArgumentException("invalid notification type!");
        }
    }
}

enum NotificationTypeEnum
{
    Email,
    Sms,
    WP,
    Cloude
}

class Test
{
    public Test([FromKeyedServices(NotificationTypeEnum.Email)] INotification notification)
    {

    }
}

//SOLID prensibi //2000 => uncle bob, 2004 SOLID prensipleri ortaya çıkartılıyor

//O => Open/Closed => bir yapı geliştirmeye açık ama değiştirmeye kapalı olmalı
//D => Dependency Inversion