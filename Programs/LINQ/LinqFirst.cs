// Program: LinqFirst
// Difficulty: Medium
// Description: Retrieves first/last elements using LINQ First, Last, FirstOrDefault.
using System;
using System.Linq;

class LinqFirst
{
    static void Main(string[] args)
    {
        int[] nums = { 3, 1, 4, 1, 5, 9, 2, 6 };
        Console.WriteLine($"First: {nums.First()}");
        Console.WriteLine($"Last: {nums.Last()}");
        Console.WriteLine($"First > 4: {nums.First(n => n > 4)}");
        Console.WriteLine($"FirstOrDefault > 100: {nums.FirstOrDefault(n => n > 100)}");
        Console.WriteLine($"Single(==9): {nums.Single(n => n == 9)}");
    }
}
