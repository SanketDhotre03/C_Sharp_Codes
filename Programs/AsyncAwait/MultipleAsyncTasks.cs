// Program: MultipleAsyncTasks
// Difficulty: Medium
// Description: Runs multiple async tasks and waits for all to complete.
using System;
using System.Threading.Tasks;

class MultipleAsyncTasks
{
    static async Task<string> ProcessAsync(string name, int delay)
    {
        Console.WriteLine($"Starting {name}...");
        await Task.Delay(delay);
        Console.WriteLine($"Finished {name}.");
        return $"{name} result";
    }

    static async Task Main(string[] args)
    {
        var t1 = ProcessAsync("TaskA", 200);
        var t2 = ProcessAsync("TaskB", 100);
        var t3 = ProcessAsync("TaskC", 150);
        var results = await Task.WhenAll(t1, t2, t3);
        Console.WriteLine("All completed:");
        foreach (var r in results) Console.WriteLine("  " + r);
    }
}
