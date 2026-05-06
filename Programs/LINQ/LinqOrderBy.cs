// Program: LinqOrderBy
// Difficulty: Medium
// Description: Sorts elements using LINQ OrderBy and ThenBy.
using System;
using System.Linq;

class LinqOrderBy
{
    record Product(string Name, string Category, double Price);

    static void Main(string[] args)
    {
        var products = new[] {
            new Product("Apple", "Fruit", 1.2),
            new Product("Banana", "Fruit", 0.5),
            new Product("Carrot", "Vegetable", 0.8),
            new Product("Broccoli", "Vegetable", 1.5),
            new Product("Cherry", "Fruit", 3.0)
        };
        var sorted = products.OrderBy(p => p.Category).ThenBy(p => p.Price);
        Console.WriteLine("Products (by category then price):");
        foreach (var p in sorted)
            Console.WriteLine($"  {p.Category,-12} {p.Name,-10} ${p.Price}");
    }
}
