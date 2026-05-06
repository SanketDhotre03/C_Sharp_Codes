// Program: CreateInstance
// Difficulty: Medium
// Description: Creates object instances dynamically at runtime using reflection.
using System;
using System.Reflection;

class CreateInstance
{
    class Shape
    {
        public string Kind { get; }
        public double Size { get; }
        public Shape(string kind, double size) { Kind = kind; Size = size; }
        public override string ToString() => $"{Kind}({Size})";
    }

    static void Main(string[] args)
    {
        // Using Activator.CreateInstance
        Type t = typeof(Shape);
        var s1 = (Shape)Activator.CreateInstance(t, "Circle", 5.0);
        Console.WriteLine("Activator: " + s1);

        // Using ConstructorInfo
        var ctor = t.GetConstructor(new[] { typeof(string), typeof(double) });
        var s2 = (Shape)ctor.Invoke(new object[] { "Rectangle", 3.0 });
        Console.WriteLine("Constructor: " + s2);

        // Create by type name (string)
        string typeName = typeof(Shape).FullName;
        Type resolved = Type.GetType(typeName + ", " + typeof(Shape).Assembly.FullName);
        if (resolved != null)
        {
            var s3 = (Shape)Activator.CreateInstance(resolved, "Triangle", 4.0);
            Console.WriteLine("By name: " + s3);
        }
    }
}
