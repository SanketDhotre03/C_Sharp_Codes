// Program: InterlockedOperations
// Difficulty: Medium
// Description: Uses Interlocked for atomic operations on shared variables.
using System;
using System.Threading;
using System.Threading.Tasks;

class InterlockedOperations
{
    static long counter = 0;
    static long total = 0;

    static async Task Main(string[] args)
    {
        var tasks = new Task[10];
        for (int i = 0; i < 10; i++)
        {
            int local = i;
            tasks[i] = Task.Run(() => {
                for (int j = 0; j < 1000; j++)
                {
                    Interlocked.Increment(ref counter);
                    Interlocked.Add(ref total, local);
                }
            });
        }
        await Task.WhenAll(tasks);
        Console.WriteLine($"Counter: {Interlocked.Read(ref counter)}");
        Console.WriteLine($"Total: {Interlocked.Read(ref total)}");
        long old = Interlocked.CompareExchange(ref counter, 0, counter);
        Console.WriteLine($"Reset. Old value was: {old}");
    }
}
