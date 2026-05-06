// Program: AnonymousTypes
// Difficulty: Medium
// Description: Demonstrates anonymous types and var keyword usage.
using System;
using System.Linq;

class AnonymousTypes
{
    static void Main(string[] args)
    {
        var person = new { Name = "Alice", Age = 30, City = "London" };
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}");

        var products = new[] {
            new { Id = 1, Name = "Apple",  Price = 1.2, Category = "Fruit" },
            new { Id = 2, Name = "Banana", Price = 0.5, Category = "Fruit" },
            new { Id = 3, Name = "Carrot", Price = 0.8, Category = "Veg"   },
        };

        var cheapFruits = products
            .Where(p => p.Category == "Fruit" && p.Price < 1.0)
            .Select(p => new { p.Name, p.Price });

        Console.WriteLine("Cheap fruits:");
        foreach (var f in cheapFruits)
            Console.WriteLine($"  {f.Name}: ${f.Price}");
    }
}
