// Program: LinqWhere
// Difficulty: Medium
// Description: Uses LINQ Where to filter a collection.
using System;
using System.Linq;

class LinqWhere
{
    static void Main(string[] args)
    {
        string[] fruits = { "apple", "banana", "cherry", "apricot", "blueberry" };
        var aFruits = fruits.Where(f => f.StartsWith("a")).ToList();
        Console.WriteLine("Fruits starting with 'a':");
        aFruits.ForEach(f => Console.WriteLine("  " + f));
    }
}
