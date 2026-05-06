// Program: SemaphoreExample
// Difficulty: Medium
// Description: Limits concurrent access using SemaphoreSlim.
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class SemaphoreExample
{
    static SemaphoreSlim semaphore = new SemaphoreSlim(3); // max 3 concurrent

    static async Task AccessResource(int id)
    {
        Console.WriteLine($"Thread {id} waiting...");
        await semaphore.WaitAsync();
        try
        {
            Console.WriteLine($"Thread {id} entered (available: {semaphore.CurrentCount})");
            await Task.Delay(200);
            Console.WriteLine($"Thread {id} leaving");
        }
        finally { semaphore.Release(); }
    }

    static async Task Main(string[] args)
    {
        var tasks = Enumerable.Range(1, 7).Select(AccessResource);
        await Task.WhenAll(tasks);
    }
}
