// Program: InspectInterface
// Difficulty: Medium
// Description: Finds all types implementing a given interface using reflection.
using System;
using System.Linq;
using System.Reflection;

interface IShape { double Area(); string Name { get; } }

class Circle    : IShape { public double Radius; public Circle(double r) => Radius = r; public double Area() => Math.PI * Radius * Radius; public string Name => "Circle"; }
class Square    : IShape { public double Side;   public Square(double s) => Side = s;   public double Area() => Side * Side;               public string Name => "Square"; }
class Triangle  : IShape { public double B, H;   public Triangle(double b, double h) { B=b; H=h; } public double Area() => 0.5*B*H; public string Name => "Triangle"; }

class InspectInterface
{
    static void Main(string[] args)
    {
        var asm = Assembly.GetExecutingAssembly();
        var shapeTypes = asm.GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IShape)) && !t.IsAbstract)
            .ToList();

        Console.WriteLine($"Types implementing IShape: {shapeTypes.Count}");
        foreach (var t in shapeTypes)
        {
            var methods = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                           .Select(m => m.Name);
            Console.WriteLine($"  {t.Name}: {string.Join(", ", methods)}");
        }

        // Create instances and call Area
        IShape[] shapes = { new Circle(5), new Square(4), new Triangle(3, 6) };
        foreach (var s in shapes)
            Console.WriteLine($"  {s.Name}.Area() = {s.Area():F2}");
    }
}
