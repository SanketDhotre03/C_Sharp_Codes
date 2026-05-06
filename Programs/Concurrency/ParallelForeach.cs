// Program: ParallelForeach
// Difficulty: Medium
// Description: Processes collections in parallel using Parallel.ForEach.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class ParallelForeach
{
    static string Process(string item)
    {
        Thread.Sleep(50);
        return item.ToUpper();
    }

    static void Main(string[] args)
    {
        var items = new List<string> { "alpha", "beta", "gamma", "delta", "epsilon" };
        var results = new System.Collections.Concurrent.ConcurrentBag<string>();

        Parallel.ForEach(items, item => {
            string result = Process(item);
            results.Add(result);
            Console.WriteLine($"Processed: {item} -> {result}");
        });

        Console.WriteLine("All done: " + string.Join(", ", results));
    }
}
