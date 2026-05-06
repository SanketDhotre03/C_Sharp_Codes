using System;

interface IShape
{
    double Area();
}

class Circle : IShape
{
    public double Radius { get; set; }
    public double Area() => Math.PI * Radius * Radius;
}

class Program45
{
    static void Main()
    {
        IShape shape = new Circle { Radius = 4 };
        Console.WriteLine($"Area: {shape.Area():F2}");
    }
}
