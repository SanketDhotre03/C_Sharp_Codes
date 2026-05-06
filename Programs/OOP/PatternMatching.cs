// Program: PatternMatching
// Difficulty: Medium
// Description: Demonstrates switch expressions and pattern matching in C#.
using System;

abstract class Shape { }
class Circle : Shape { public double Radius; }
class Rectangle : Shape { public double Width, Height; }
class Triangle : Shape { public double Base, Height; }

class PatternMatching
{
    static double Area(Shape shape) => shape switch
    {
        Circle c    => Math.PI * c.Radius * c.Radius,
        Rectangle r => r.Width * r.Height,
        Triangle t  => 0.5 * t.Base * t.Height,
        _           => throw new ArgumentException("Unknown shape")
    };

    static string Classify(object obj) => obj switch
    {
        int n when n < 0  => "Negative integer",
        int n when n == 0 => "Zero",
        int n             => "Positive integer",
        string s when s.Length == 0 => "Empty string",
        string s          => $"String of length {s.Length}",
        null              => "Null value",
        _                 => "Unknown type"
    };

    static void Main(string[] args)
    {
        Shape[] shapes = {
            new Circle { Radius = 5 },
            new Rectangle { Width = 4, Height = 6 },
            new Triangle { Base = 3, Height = 8 }
        };
        foreach (var s in shapes)
            Console.WriteLine($"{s.GetType().Name}: Area = {Area(s):F2}");

        object[] objects = { -5, 0, 42, "", "hello", null };
        foreach (var o in objects)
            Console.WriteLine($"{o ?? "null"}: {Classify(o)}");
    }
}
