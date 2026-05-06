// Program: LinqFlattening
// Difficulty: Medium
// Description: Flattens nested structures using LINQ SelectMany and Concat.
using System;
using System.Linq;
using System.Collections.Generic;

class LinqFlattening
{
    static void Main(string[] args)
    {
        int[][] matrix = { new[]{1,2,3}, new[]{4,5,6}, new[]{7,8,9} };
        var flat = matrix.SelectMany(row => row);
        Console.WriteLine("Flat matrix: " + string.Join(", ", flat));

        List<List<string>> nested = new List<List<string>>
        {
            new List<string> { "a", "b" },
            new List<string> { "c", "d", "e" },
            new List<string> { "f" }
        };
        var allStrings = nested.SelectMany(x => x);
        Console.WriteLine("Flattened strings: " + string.Join(", ", allStrings));
    }
}
