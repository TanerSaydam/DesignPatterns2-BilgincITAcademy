Console.WriteLine("Adapter Pattern");

INotification service1 = new EmailNotification();
service1.Send("tanersaydam@gmail.com", "Hello world");

INotification service2 = new SmsAdapter(new SmsService());
service2.Send("+905546549006", "Hello world from phone!");

Console.ReadLine();

interface INotification
{
    void Send(string to, string body);
}

class EmailNotification : INotification
{
    public void Send(string to, string body)
    {
        Console.WriteLine("[Email] to: {0}, body: {1}", to, body);
    }
}

class SmsService
{
    public void Send(string phoneNumber, string message)
    {
        Console.WriteLine("[SMS] phoneNumber: {0}, body: {1}", phoneNumber, message);
    }
}

class SmsAdapter(SmsService smsService) : INotification
{
    public void Send(string to, string body)
    {
        smsService.Send(to, body);
    }
}