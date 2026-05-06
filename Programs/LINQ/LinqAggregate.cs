// Program: LinqAggregate
// Difficulty: Medium
// Description: Uses LINQ Aggregate to perform custom accumulation.
using System;
using System.Linq;

class LinqAggregate
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        int product = nums.Aggregate((acc, n) => acc * n);
        Console.WriteLine($"Product: {product}");

        string sentence = "the quick brown fox";
        string capitalized = sentence.Split(' ')
            .Aggregate("", (acc, w) => acc + char.ToUpper(w[0]) + w[1..] + " ").Trim();
        Console.WriteLine($"Capitalized: {capitalized}");
    }
}
