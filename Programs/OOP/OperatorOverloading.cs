// Program: OperatorOverloading
// Difficulty: Medium
// Description: Overloads arithmetic and comparison operators for a custom type.
using System;

struct Vector2D
{
    public double X, Y;
    public Vector2D(double x, double y) { X = x; Y = y; }
    public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D(a.X + b.X, a.Y + b.Y);
    public static Vector2D operator -(Vector2D a, Vector2D b) => new Vector2D(a.X - b.X, a.Y - b.Y);
    public static Vector2D operator *(Vector2D v, double s) => new Vector2D(v.X * s, v.Y * s);
    public static bool operator ==(Vector2D a, Vector2D b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(Vector2D a, Vector2D b) => !(a == b);
    public double Magnitude => Math.Sqrt(X * X + Y * Y);
    public override string ToString() => $"({X:F1}, {Y:F1})";
    public override bool Equals(object obj) => obj is Vector2D v && this == v;
    public override int GetHashCode() => HashCode.Combine(X, Y);
}

class OperatorOverloading
{
    static void Main(string[] args)
    {
        var v1 = new Vector2D(3, 4);
        var v2 = new Vector2D(1, 2);
        Console.WriteLine($"v1 = {v1}, |v1| = {v1.Magnitude}");
        Console.WriteLine($"v1 + v2 = {v1 + v2}");
        Console.WriteLine($"v1 - v2 = {v1 - v2}");
        Console.WriteLine($"v1 * 2 = {v1 * 2}");
        Console.WriteLine($"v1 == v1: {v1 == v1}");
    }
}
