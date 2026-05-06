// Program: MultipleInterfaces
// Difficulty: Medium
// Description: Implements multiple interfaces in a single class.
using System;

interface IFlyable { void Fly(); int MaxAltitude { get; } }
interface ISwimmable { void Swim(); int MaxDepth { get; } }
interface IRunnable { void Run(); int MaxSpeed { get; } }

class Duck : IFlyable, ISwimmable, IRunnable
{
    public int MaxAltitude => 100;
    public int MaxDepth => 2;
    public int MaxSpeed => 30;
    public void Fly() => Console.WriteLine($"Duck flies up to {MaxAltitude}m");
    public void Swim() => Console.WriteLine($"Duck swims up to {MaxDepth}m deep");
    public void Run() => Console.WriteLine($"Duck runs at {MaxSpeed}km/h");
}

class MultipleInterfaces
{
    static void Main(string[] args)
    {
        var duck = new Duck();
        duck.Fly(); duck.Swim(); duck.Run();

        IFlyable f = duck; f.Fly();
        ISwimmable s = duck; s.Swim();
    }
}
