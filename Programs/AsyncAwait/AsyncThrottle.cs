// Program: AsyncThrottle
// Difficulty: High
// Description: Throttles concurrent async operations using SemaphoreSlim.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class AsyncThrottle
{
    static async Task<string> ProcessItem(int id, SemaphoreSlim semaphore)
    {
        await semaphore.WaitAsync();
        try
        {
            Console.WriteLine($"Processing {id}...");
            await Task.Delay(100);
            return $"Result {id}";
        }
        finally
        {
            semaphore.Release();
        }
    }

    static async Task Main(string[] args)
    {
        int maxConcurrent = 3;
        var semaphore = new SemaphoreSlim(maxConcurrent);
        var tasks = Enumerable.Range(1, 8).Select(i => ProcessItem(i, semaphore));
        var results = await Task.WhenAll(tasks);
        Console.WriteLine("All done: " + string.Join(", ", results));
    }
}
