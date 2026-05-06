// Program: LinqAll
// Difficulty: Medium
// Description: Checks if all elements satisfy a condition using LINQ All.
using System;
using System.Linq;

class LinqAll
{
    static void Main(string[] args)
    {
        int[] positives = { 1, 5, 3, 9, 2 };
        int[] mixed = { 1, -5, 3, 9, 2 };
        Console.WriteLine($"All positive (positives): {positives.All(n => n > 0)}");
        Console.WriteLine($"All positive (mixed): {mixed.All(n => n > 0)}");

        string[] words = { "hello", "world", "foo" };
        Console.WriteLine($"All non-empty: {words.All(w => w.Length > 0)}");
    }
}
