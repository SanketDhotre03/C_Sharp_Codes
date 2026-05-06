// Program: LinqDistinct
// Difficulty: Medium
// Description: Removes duplicates using LINQ Distinct.
using System;
using System.Linq;

class LinqDistinct
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 2, 3, 3, 3, 4, 5, 5 };
        var unique = nums.Distinct().OrderBy(n => n);
        Console.WriteLine("Unique: " + string.Join(", ", unique));

        string[] words = { "apple", "Apple", "APPLE", "banana" };
        var uniqueWords = words.Distinct(StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("Unique words: " + string.Join(", ", uniqueWords));
    }
}
