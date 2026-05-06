// Program: MethodOverloading
// Difficulty: Medium
// Description: Demonstrates compile-time polymorphism through method overloading.
using System;

class Calculator
{
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
    public int Add(int a, int b, int c) => a + b + c;
    public string Add(string a, string b) => a + b;

    public void Display(int n) => Console.WriteLine($"Int: {n}");
    public void Display(double d) => Console.WriteLine($"Double: {d:F2}");
    public void Display(string s) => Console.WriteLine($"String: {s}");
}

class MethodOverloading
{
    static void Main(string[] args)
    {
        var calc = new Calculator();
        Console.WriteLine(calc.Add(3, 4));
        Console.WriteLine(calc.Add(3.5, 4.5));
        Console.WriteLine(calc.Add(1, 2, 3));
        Console.WriteLine(calc.Add("Hello, ", "World!"));
        calc.Display(42);
        calc.Display(3.14);
        calc.Display("Test");
    }
}
