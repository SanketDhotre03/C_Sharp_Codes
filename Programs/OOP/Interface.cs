// Program: Interface
// Difficulty: Medium
// Description: Demonstrates C# interfaces as contracts for classes.
using System;

interface IDrawable
{
    void Draw();
    string Color { get; set; }
}

interface IResizable
{
    void Resize(double factor);
}

class Circle : IDrawable, IResizable
{
    public string Color { get; set; }
    public double Radius { get; private set; }
    public Circle(double radius, string color) { Radius = radius; Color = color; }
    public void Draw() => Console.WriteLine($"Drawing {Color} circle with radius {Radius:F1}");
    public void Resize(double factor) { Radius *= factor; Console.WriteLine($"Resized to radius {Radius:F1}"); }
}

class Interface
{
    static void Main(string[] args)
    {
        IDrawable drawable = new Circle(5.0, "Red");
        drawable.Draw();
        ((IResizable)drawable).Resize(1.5);
        drawable.Draw();
    }
}
