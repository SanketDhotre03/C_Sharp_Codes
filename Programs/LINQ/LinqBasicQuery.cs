// Program: LinqBasicQuery
// Difficulty: Medium
// Description: Demonstrates LINQ query syntax on a collection.
using System;
using System.Collections.Generic;
using System.Linq;

class LinqBasicQuery
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 5, 2, 9, 1, 7, 3, 8, 4, 6 };
        var query = from n in numbers
                    where n > 4
                    orderby n
                    select n;
        Console.WriteLine("Numbers > 4 (sorted): " + string.Join(", ", query));
    }
}
