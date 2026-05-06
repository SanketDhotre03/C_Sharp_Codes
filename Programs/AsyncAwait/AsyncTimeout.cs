// Program: AsyncTimeout
// Difficulty: Medium
// Description: Implements a timeout for async operations.
using System;
using System.Threading;
using System.Threading.Tasks;

class AsyncTimeout
{
    static async Task<string> FetchDataAsync()
    {
        await Task.Delay(2000);
        return "Data fetched";
    }

    static async Task<T> WithTimeout<T>(Task<T> task, TimeSpan timeout)
    {
        using var cts = new CancellationTokenSource();
        var timeoutTask = Task.Delay(timeout, cts.Token);
        var completed = await Task.WhenAny(task, timeoutTask);
        if (completed == timeoutTask) throw new TimeoutException("Operation timed out");
        cts.Cancel();
        return await task;
    }

    static async Task Main(string[] args)
    {
        try
        {
            var result = await WithTimeout(FetchDataAsync(), TimeSpan.FromSeconds(1));
            Console.WriteLine(result);
        }
        catch (TimeoutException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
