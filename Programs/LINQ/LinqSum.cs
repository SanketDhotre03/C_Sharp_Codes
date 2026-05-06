// Program: LinqSum
// Difficulty: Medium
// Description: Calculates sums using LINQ Sum.
using System;
using System.Linq;

class LinqSum
{
    record Product(string Name, double Price, int Qty);

    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Sum: {nums.Sum()}");
        Console.WriteLine($"Sum of squares: {nums.Sum(n => n * n)}");

        var cart = new[] {
            new Product("Apple", 0.5, 4),
            new Product("Bread", 2.5, 2),
            new Product("Milk",  1.2, 3)
        };
        double total = cart.Sum(p => p.Price * p.Qty);
        Console.WriteLine($"Cart total: ${total:F2}");
    }
}
