// Program: LinqSelectMany
// Difficulty: Medium
// Description: Flattens nested collections using LINQ SelectMany.
using System;
using System.Linq;

class LinqSelectMany
{
    static void Main(string[] args)
    {
        var orders = new[] {
            new { Customer = "Alice", Items = new[] { "Laptop", "Mouse" } },
            new { Customer = "Bob",   Items = new[] { "Phone" } },
            new { Customer = "Carol", Items = new[] { "Keyboard", "Monitor", "Headset" } }
        };
        var allItems = orders.SelectMany(o => o.Items);
        Console.WriteLine("All items: " + string.Join(", ", allItems));

        var withCustomer = orders.SelectMany(o => o.Items, (o, item) => $"{o.Customer}:{item}");
        foreach (var x in withCustomer) Console.WriteLine("  " + x);
    }
}
