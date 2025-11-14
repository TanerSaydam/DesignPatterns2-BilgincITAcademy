Console.WriteLine("Decorator Pattern");

IMailService service = new MailService();
service = new LoggingMailDecorator(service);
service = new SignatureMailDecorator(service);

service.Send("info@taner.com", "Hello", " Hi, how are you?");

Console.ReadLine();

interface IMailService
{
    void Send(string to, string subject, string body);
}

class MailService : IMailService
{
    public void Send(string to, string subject, string body)
    {
        Console.WriteLine("[Mail Service] Sending email...\nTo: {0}\nSubject: {1}\nBody: {2}", to, subject, body);
    }
}

abstract class MailDecorator : IMailService
{
    public IMailService _service;

    protected MailDecorator(IMailService service)
    {
        _service = service;
    }

    public abstract void Send(string to, string subject, string body);
}

class LoggingMailDecorator : MailDecorator
{
    public LoggingMailDecorator(IMailService service) : base(service)
    {
    }

    public override void Send(string to, string subject, string body)
    {
        Console.WriteLine("[LOG] Sending email...");
        _service.Send(to, subject, body);
    }
}

class SignatureMailDecorator : MailDecorator
{
    public SignatureMailDecorator(IMailService service) : base(service)
    {
    }

    public override void Send(string to, string subject, string body)
    {
        body += "\n\nBest Regards!";
        _service.Send(to, subject, body);
    }
}