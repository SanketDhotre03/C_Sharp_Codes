// Program: MediatorPattern
// Difficulty: High
// Description: Mediator pattern centralizes communication between components.
using System;
using System.Collections.Generic;

interface IMediator { void Send(string message, string sender); }

class ChatRoom : IMediator
{
    Dictionary<string, ChatUser> users = new Dictionary<string, ChatUser>();
    public void Register(ChatUser user) { users[user.Name] = user; user.SetMediator(this); }
    public void Send(string message, string sender)
    {
        foreach (var kv in users)
            if (kv.Key != sender)
                kv.Value.Receive($"[{sender}]: {message}");
    }
}

class ChatUser
{
    public string Name { get; }
    IMediator mediator;
    public ChatUser(string name) => Name = name;
    public void SetMediator(IMediator m) => mediator = m;
    public void Say(string msg) { Console.WriteLine($"{Name} says: {msg}"); mediator.Send(msg, Name); }
    public void Receive(string msg) => Console.WriteLine($"  {Name} received {msg}");
}

class MediatorPattern
{
    static void Main(string[] args)
    {
        var room = new ChatRoom();
        var alice = new ChatUser("Alice");
        var bob   = new ChatUser("Bob");
        var carol = new ChatUser("Carol");
        room.Register(alice); room.Register(bob); room.Register(carol);
        alice.Say("Hello everyone!");
        bob.Say("Hi Alice!");
    }
}
