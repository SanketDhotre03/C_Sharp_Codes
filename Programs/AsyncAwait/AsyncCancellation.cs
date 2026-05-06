// Program: AsyncCancellation
// Difficulty: Medium
// Description: Demonstrates cancellation of async operations using CancellationToken.
using System;
using System.Threading;
using System.Threading.Tasks;

class AsyncCancellation
{
    static async Task LongRunningWork(CancellationToken ct)
    {
        for (int i = 0; i < 10; i++)
        {
            ct.ThrowIfCancellationRequested();
            Console.WriteLine($"Working... step {i + 1}");
            await Task.Delay(200, ct);
        }
    }

    static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
        try
        {
            await LongRunningWork(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Work was cancelled!");
        }
    }
}
