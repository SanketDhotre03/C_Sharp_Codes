// Program: InspectAssembly
// Difficulty: High
// Description: Inspects types and members in the current assembly.
using System;
using System.Linq;
using System.Reflection;

class InspectAssembly
{
    static void Main(string[] args)
    {
        Assembly asm = Assembly.GetExecutingAssembly();
        Console.WriteLine($"Assembly: {asm.GetName().Name}");
        Console.WriteLine($"Location: {System.IO.Path.GetFileName(asm.Location)}");

        var types = asm.GetTypes().OrderBy(t => t.Name);
        Console.WriteLine($"\nTotal types: {types.Count()}");
        Console.WriteLine("Types:");
        foreach (var t in types)
        {
            string kind = t.IsInterface ? "interface" : t.IsEnum ? "enum" : t.IsAbstract ? "abstract class" : "class";
            Console.WriteLine($"  [{kind}] {t.Name}");
        }

        // Find all static methods
        var staticMethods = types
            .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
            .ToList();
        Console.WriteLine($"\nStatic public methods: {staticMethods.Count}");
    }
}
