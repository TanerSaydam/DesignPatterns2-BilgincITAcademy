using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Singleton Pattern");

#region Old solution
//Logger logger1 = Logger.Instance;
//logger1.Log("Hello world1");

//Logger logger2 = Logger.Instance;
//logger1.Log("Hello world2");

//Logger logger3 = Logger.Instance;
//logger1.Log("Hello world3");

//....
#endregion

#region New Solution
ServiceCollection services = new();
services.AddSingleton<LoggerDI>();
services.AddSingleton<Test>();

var srv = services.BuildServiceProvider();
//var test = srv.GetService<Test>();
var logger1 = srv.GetRequiredService<LoggerDI>();
logger1.Log("Hello world 1");

var logger2 = srv.GetRequiredService<LoggerDI>();
logger1.Log("Hello world 2");

var logger3 = srv.GetRequiredService<LoggerDI>();
logger1.Log("Hello world 3");

#endregion

Console.ReadLine();

class LoggerDI
{
    public LoggerDI()
    {
    }
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class Test
{
    public Test(LoggerDI logger)
    {
        logger.Log("Hello world from Test");
    }
}

class Logger
{
    //private static Logger? _instance; //.net 9 ve öncesi çözümü
    private static readonly object _lock = new();
    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (field is null) //.net 10 çözümü
                {
                    field = new Logger();
                }
            }

            return field;
        }
    }

    private Logger()
    {
    }
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}