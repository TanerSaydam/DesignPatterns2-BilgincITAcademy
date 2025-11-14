Console.WriteLine("Bridge Pattern");

ILogProvider consoleProvider = new ConsoleLogProvider();
ILogProvider fileProvider = new FileLogProvider();

LogBase auditLog = new AuditLog(consoleProvider);
auditLog.Log("Hello world");

Console.ReadLine();

#region Implementation (Nasıl Yapıyorum?)
interface ILogProvider
{
    void Log(string message);
}

class ConsoleLogProvider : ILogProvider
{
    public void Log(string message)
    {
        Console.WriteLine("[Console Log]: {0}", message);
    }
}

class FileLogProvider : ILogProvider
{
    public void Log(string message)
    {
        Console.WriteLine("[File Log]: {0}", message);
    }
}

class EmailLogProvider : ILogProvider
{
    public void Log(string message)
    {
        Console.WriteLine("[Email Log]: {0}", message);
    }
}
#endregion

#region Abstraction (Ne yapıyorum?)
abstract class LogBase
{
    public readonly ILogProvider _logProvider;

    protected LogBase(ILogProvider logProvider)
    {
        _logProvider = logProvider;
    }

    public abstract void Log(string message);
}

class AuditLog : LogBase
{
    public AuditLog(ILogProvider logProvider) : base(logProvider)
    {
    }
    public override void Log(string message)
    {
        //kendi işlemlerim
        _logProvider.Log(message);
    }
}

class AppLog : LogBase
{
    public AppLog(ILogProvider logProvider) : base(logProvider)
    {
    }
    public override void Log(string message)
    {
        //kendi işlemlerim
        _logProvider.Log(message);
    }
}
#endregion
