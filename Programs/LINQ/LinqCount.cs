// Program: LinqCount
// Difficulty: Medium
// Description: Counts elements in a sequence using LINQ Count and LongCount.
using System;
using System.Linq;

class LinqCount
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine($"Total: {nums.Count()}");
        Console.WriteLine($"Even count: {nums.Count(n => n % 2 == 0)}");
        Console.WriteLine($"Odd count: {nums.Count(n => n % 2 != 0)}");

        var words = new[] { "hello", "world", "foo", "bar", "baz" };
        Console.WriteLine($"Short words (<=3): {words.Count(w => w.Length <= 3)}");
    }
}
