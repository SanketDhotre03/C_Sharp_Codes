// Program: FactoryPattern
// Difficulty: Medium
// Description: Factory Method pattern for creating objects without specifying concrete classes.
using System;

abstract class Notification
{
    public abstract void Send(string message);
}

class EmailNotification : Notification
{
    public override void Send(string message) => Console.WriteLine($"Email: {message}");
}

class SMSNotification : Notification
{
    public override void Send(string message) => Console.WriteLine($"SMS: {message}");
}

class PushNotification : Notification
{
    public override void Send(string message) => Console.WriteLine($"Push: {message}");
}

static class NotificationFactory
{
    public static Notification Create(string type) => type.ToLower() switch
    {
        "email" => new EmailNotification(),
        "sms"   => new SMSNotification(),
        "push"  => new PushNotification(),
        _       => throw new ArgumentException($"Unknown type: {type}")
    };
}

class FactoryPattern
{
    static void Main(string[] args)
    {
        string[] types = { "email", "sms", "push" };
        foreach (var t in types)
        {
            var notification = NotificationFactory.Create(t);
            notification.Send($"Hello from {t}!");
        }
    }
}
