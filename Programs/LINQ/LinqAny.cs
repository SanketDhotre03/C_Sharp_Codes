// Program: LinqAny
// Difficulty: Medium
// Description: Checks if any element satisfies a condition using LINQ Any.
using System;
using System.Linq;

class LinqAny
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 5, 3, 9, 2 };
        Console.WriteLine($"Any > 8: {nums.Any(n => n > 8)}");
        Console.WriteLine($"Any < 0: {nums.Any(n => n < 0)}");

        string[] words = { "cat", "dog", "elephant" };
        Console.WriteLine($"Any long word: {words.Any(w => w.Length > 5)}");
        Console.WriteLine($"Non-empty: {words.Any()}");
    }
}
