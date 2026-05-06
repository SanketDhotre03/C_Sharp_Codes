// Program: LinqJoin
// Difficulty: Medium
// Description: Demonstrates LINQ inner join between two collections.
using System;
using System.Linq;

class LinqJoin
{
    record Order(int Id, int CustomerId, string Item);
    record Customer(int Id, string Name);

    static void Main(string[] args)
    {
        var customers = new[] {
            new Customer(1, "Alice"), new Customer(2, "Bob"), new Customer(3, "Charlie")
        };
        var orders = new[] {
            new Order(101, 1, "Laptop"), new Order(102, 2, "Phone"),
            new Order(103, 1, "Tablet"), new Order(104, 3, "Monitor")
        };
        var result = orders.Join(customers,
            o => o.CustomerId, c => c.Id,
            (o, c) => new { c.Name, o.Item });
        foreach (var r in result)
            Console.WriteLine($"{r.Name} ordered {r.Item}");
    }
}
