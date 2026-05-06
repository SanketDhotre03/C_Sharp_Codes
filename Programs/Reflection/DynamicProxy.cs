// Program: DynamicProxy
// Difficulty: High
// Description: Implements a simple dynamic proxy using DispatchProxy.
using System;
using System.Reflection;

interface IService
{
    string GetData(int id);
    void ProcessData(string data);
}

class RealService : IService
{
    public string GetData(int id) => $"Data for ID {id}";
    public void ProcessData(string data) => Console.WriteLine($"Processing: {data}");
}

class LoggingProxy<T> : DispatchProxy
{
    private T _target;

    protected override object Invoke(MethodInfo method, object[] args)
    {
        Console.WriteLine($"[LOG] Calling {method.Name}({string.Join(", ", args ?? new object[0])})");
        var result = method.Invoke(_target, args);
        Console.WriteLine($"[LOG] {method.Name} returned: {result ?? "void"}");
        return result;
    }

    public static T Create(T target)
    {
        T proxy = Create<T, LoggingProxy<T>>();
        ((LoggingProxy<T>)(object)proxy)._target = target;
        return proxy;
    }
}

class DynamicProxy
{
    static void Main(string[] args)
    {
        IService real = new RealService();
        IService proxy = LoggingProxy<IService>.Create(real);
        proxy.GetData(42);
        proxy.ProcessData("Hello");
    }
}
