Console.WriteLine("Mediator Pattern");

var chatRoom = new ChatRoomMediator();
var user1 = new User() { UserName = "Taner" };
var user2 = new User() { UserName = "Ahmet" };
var user3 = new User() { UserName = "Ayşe" };

chatRoom.Register(user1);
chatRoom.Register(user2);
chatRoom.Register(user3);

chatRoom.Send("Taner", "Ahmet", "Hello!!");
chatRoom.Send("Ayşe", "Ahmet", "Whatsapp!");

Console.ReadLine();

class ChatRoomMediator
{
    private readonly List<User> _users = new();
    public void Register(User user)
    {
        _users.Add(user);
    }

    public void Send(string from, string to, string message)
    {
        var user = _users.FirstOrDefault(p => p.UserName == to);
        if (user is not null)
        {
            user.Receive(from, message);
        }
    }
}

class User
{
    public string UserName { get; set; } = default!;
    public void Receive(string name, string message)
    {
        Console.WriteLine("{0} received from {1}: {2}", UserName, name, message);
    }
}
