// Program: MethodOverriding
// Difficulty: Medium
// Description: Demonstrates method overriding with virtual/override keywords.
using System;

class Logger
{
    public virtual void Log(string message) => Console.WriteLine($"[LOG] {message}");
    public virtual void Error(string message) => Console.WriteLine($"[ERROR] {message}");
}

class TimestampLogger : Logger
{
    public override void Log(string message) =>
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [LOG] {message}");
    public override void Error(string message) =>
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [ERROR] {message}");
}

class FileLogger : Logger
{
    string prefix;
    public FileLogger(string prefix) => this.prefix = prefix;
    public override void Log(string message) =>
        Console.WriteLine($"[FILE:{prefix}] {message}");
}

class MethodOverriding
{
    static void Main(string[] args)
    {
        Logger[] loggers = { new Logger(), new TimestampLogger(), new FileLogger("app.log") };
        foreach (var l in loggers)
        {
            l.Log("Application started");
            l.Error("Something went wrong");
        }
    }
}
