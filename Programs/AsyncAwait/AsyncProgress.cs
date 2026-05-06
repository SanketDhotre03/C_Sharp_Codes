// Program: AsyncProgress
// Difficulty: Medium
// Description: Reports progress from async operations using IProgress<T>.
using System;
using System.Threading.Tasks;

class AsyncProgress
{
    static async Task ProcessItemsAsync(int count, IProgress<int> progress)
    {
        for (int i = 1; i <= count; i++)
        {
            await Task.Delay(50);
            progress.Report(i * 100 / count);
        }
    }

    static async Task Main(string[] args)
    {
        var progress = new Progress<int>(pct => Console.WriteLine($"Progress: {pct}%"));
        Console.WriteLine("Starting long operation...");
        await ProcessItemsAsync(5, progress);
        Console.WriteLine("Done!");
    }
}
