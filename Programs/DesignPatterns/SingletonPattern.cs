// Program: SingletonPattern
// Difficulty: Medium
// Description: Thread-safe Singleton pattern using double-checked locking.
using System;

class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();
    private int _callCount;

    private Singleton() { Console.WriteLine("Singleton created."); }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
                lock (_lock)
                    if (_instance == null)
                        _instance = new Singleton();
            return _instance;
        }
    }

    public void DoWork() => Console.WriteLine($"Working... call #{++_callCount}");
}

class SingletonPattern
{
    static void Main(string[] args)
    {
        var a = Singleton.Instance;
        var b = Singleton.Instance;
        Console.WriteLine($"Same instance: {ReferenceEquals(a, b)}");
        a.DoWork(); b.DoWork();
    }
}
