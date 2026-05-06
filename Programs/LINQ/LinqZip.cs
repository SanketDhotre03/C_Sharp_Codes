// Program: LinqZip
// Difficulty: Medium
// Description: Combines two sequences element-by-element using LINQ Zip.
using System;
using System.Linq;

class LinqZip
{
    static void Main(string[] args)
    {
        string[] names = { "Alice", "Bob", "Charlie" };
        int[] scores  = { 95, 80, 87 };
        var result = names.Zip(scores, (n, s) => $"{n}: {s}");
        foreach (var r in result) Console.WriteLine(r);

        int[] a = { 1, 2, 3 }, b = { 4, 5, 6 };
        var sums = a.Zip(b, (x, y) => x + y);
        Console.WriteLine("Element-wise sums: " + string.Join(", ", sums));
    }
}
