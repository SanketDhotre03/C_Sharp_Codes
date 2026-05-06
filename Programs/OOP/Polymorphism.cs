// Program: Polymorphism
// Difficulty: Medium
// Description: Demonstrates runtime polymorphism with virtual methods.
using System;

abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
    public override string ToString() => $"{GetType().Name}: Area={Area():F2}, Perimeter={Perimeter():F2}";
}

class Circle : Shape
{
    double radius;
    public Circle(double r) => radius = r;
    public override double Area() => Math.PI * radius * radius;
    public override double Perimeter() => 2 * Math.PI * radius;
}

class Rectangle : Shape
{
    double w, h;
    public Rectangle(double w, double h) { this.w = w; this.h = h; }
    public override double Area() => w * h;
    public override double Perimeter() => 2 * (w + h);
}

class Triangle : Shape
{
    double a, b, c;
    public Triangle(double a, double b, double c) { this.a = a; this.b = b; this.c = c; }
    public override double Area() { double s = (a + b + c) / 2; return Math.Sqrt(s * (s-a) * (s-b) * (s-c)); }
    public override double Perimeter() => a + b + c;
}

class Polymorphism
{
    static void Main(string[] args)
    {
        Shape[] shapes = { new Circle(5), new Rectangle(4, 6), new Triangle(3, 4, 5) };
        foreach (var s in shapes) Console.WriteLine(s);
    }
}
