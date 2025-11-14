Console.WriteLine("Chain of Responsibility Pattern");

var level1 = new Level1Support();
var level2 = new Level2Support();
var level3 = new Level3Support();

level1.SetNext(level2);//.SetNext(level3);

level1.Handle(new SupportRequest("Password reset", 1));
level1.Handle(new SupportRequest("Email not response", 2));
//level1.Handle(new SupportRequest("System doesn't work", 3));

Console.ReadLine();

class SupportRequest
{
    public SupportRequest(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public string Name { get; set; }
    public int Level { get; set; }
}

abstract class SupportHandler
{
    public SupportHandler _next = default!;
    public SupportHandler SetNext(SupportHandler next)
    {
        _next = next;
        return this;
    }

    public abstract void Handle(SupportRequest request);
}

class Level1Support : SupportHandler
{
    public override void Handle(SupportRequest request)
    {
        if (request.Level == 1)
        {
            Console.WriteLine("[Level 1] Resvoled the issue!");
        }
        else
        {
            _next.Handle(request);
        }
    }
}

class Level2Support : SupportHandler
{
    public override void Handle(SupportRequest request)
    {
        if (request.Level == 2)
        {
            Console.WriteLine("[Level 2] Resvoled the issue!");
        }
        else
        {
            _next.Handle(request);
        }
    }
}

class Level3Support : SupportHandler
{
    public override void Handle(SupportRequest request)
    {
        if (request.Level == 3)
        {
            Console.WriteLine("[Level 3] Resvoled the issue!");
        }
        else
        {
            _next.Handle(request);
        }
    }
}