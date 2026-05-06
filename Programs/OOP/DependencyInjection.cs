// Program: DependencyInjection
// Difficulty: High
// Description: Demonstrates the Dependency Injection pattern without frameworks.
using System;

interface IMessageService
{
    void Send(string to, string message);
}

class EmailService : IMessageService
{
    public void Send(string to, string message) =>
        Console.WriteLine($"Email to {to}: {message}");
}

class SmsService : IMessageService
{
    public void Send(string to, string message) =>
        Console.WriteLine($"SMS to {to}: {message}");
}

class NotificationManager
{
    private readonly IMessageService _service;
    public NotificationManager(IMessageService service) => _service = service;
    public void Notify(string user, string msg) => _service.Send(user, msg);
}

class DependencyInjection
{
    static void Main(string[] args)
    {
        var emailNotifier = new NotificationManager(new EmailService());
        var smsNotifier   = new NotificationManager(new SmsService());

        emailNotifier.Notify("alice@example.com", "Hello via email!");
        smsNotifier.Notify("+1234567890", "Hello via SMS!");
    }
}
