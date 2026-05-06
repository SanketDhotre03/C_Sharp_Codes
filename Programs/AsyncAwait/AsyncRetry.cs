// Program: AsyncRetry
// Difficulty: High
// Description: Implements retry logic for async operations with exponential backoff.
using System;
using System.Threading.Tasks;

class AsyncRetry
{
    static int _attempts = 0;

    static async Task<string> UnreliableOperation()
    {
        _attempts++;
        await Task.Delay(50);
        if (_attempts < 3) throw new Exception($"Attempt {_attempts} failed");
        return "Success on attempt " + _attempts;
    }

    static async Task<T> RetryAsync<T>(Func<Task<T>> operation, int maxRetries, TimeSpan delay)
    {
        for (int i = 0; i <= maxRetries; i++)
        {
            try { return await operation(); }
            catch (Exception ex)
            {
                if (i == maxRetries) throw;
                Console.WriteLine($"Retry {i + 1}/{maxRetries}: {ex.Message}");
                await Task.Delay(delay * (int)Math.Pow(2, i));
            }
        }
        throw new Exception("Unreachable");
    }

    static async Task Main(string[] args)
    {
        try
        {
            var result = await RetryAsync(UnreliableOperation, 5, TimeSpan.FromMilliseconds(100));
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed: " + ex.Message);
        }
    }
}
