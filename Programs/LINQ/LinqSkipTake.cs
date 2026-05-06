// Program: LinqSkipTake
// Difficulty: Medium
// Description: Uses LINQ Skip and Take for pagination.
using System;
using System.Linq;

class LinqSkipTake
{
    static void Main(string[] args)
    {
        int[] data = Enumerable.Range(1, 20).ToArray();
        int pageSize = 5;
        for (int page = 0; page * pageSize < data.Length; page++)
        {
            var pageData = data.Skip(page * pageSize).Take(pageSize);
            Console.WriteLine($"Page {page + 1}: {string.Join(", ", pageData)}");
        }
    }
}
