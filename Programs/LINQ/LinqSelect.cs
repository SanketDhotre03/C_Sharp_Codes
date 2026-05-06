// Program: LinqSelect
// Difficulty: Medium
// Description: Uses LINQ Select to project/transform elements.
using System;
using System.Linq;

class LinqSelect
{
    record Person(string Name, int Age);

    static void Main(string[] args)
    {
        var people = new[] {
            new Person("Alice", 30),
            new Person("Bob", 25),
            new Person("Charlie", 35)
        };
        var names = people.Select(p => p.Name.ToUpper());
        Console.WriteLine("Names: " + string.Join(", ", names));

        var info = people.Select(p => new { p.Name, Category = p.Age >= 30 ? "Senior" : "Junior" });
        foreach (var x in info)
            Console.WriteLine($"  {x.Name}: {x.Category}");
    }
}
