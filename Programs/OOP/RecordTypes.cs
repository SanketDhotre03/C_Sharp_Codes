// Program: RecordTypes
// Difficulty: Medium
// Description: Demonstrates C# 9+ record types for immutable value-like classes.
using System;

record Point(double X, double Y)
{
    public double Distance => Math.Sqrt(X * X + Y * Y);
}

record Person(string FirstName, string LastName, int Age)
{
    public string FullName => $"{FirstName} {LastName}";
}

class RecordTypes
{
    static void Main(string[] args)
    {
        var p1 = new Point(3, 4);
        var p2 = new Point(3, 4);
        var p3 = new Point(1, 2);

        Console.WriteLine($"p1: {p1}, Distance: {p1.Distance}");
        Console.WriteLine($"p1 == p2: {p1 == p2}");  // True (value equality)
        Console.WriteLine($"p1 == p3: {p1 == p3}");  // False

        var alice = new Person("Alice", "Smith", 30);
        var olderAlice = alice with { Age = 31 };  // non-destructive mutation
        Console.WriteLine($"Original: {alice}");
        Console.WriteLine($"Modified: {olderAlice}");
    }
}
