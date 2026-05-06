// Program: HttpClientTimeout
// Difficulty: Medium
// Description: Handles HTTP request timeouts and retries.
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class HttpClientTimeout
{
    static async Task<string> GetWithRetry(string url, int maxRetries)
    {
        using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(3) };
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                Console.WriteLine($"Attempt {attempt}...");
                return await client.GetStringAsync(url);
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine($"Timeout on attempt {attempt}");
                if (attempt == maxRetries) throw;
                await Task.Delay(TimeSpan.FromSeconds(attempt));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error: {ex.Message}");
                if (attempt == maxRetries) throw;
            }
        }
        return null;
    }

    static async Task Main(string[] args)
    {
        try
        {
            string result = await GetWithRetry("https://httpbin.org/delay/1", maxRetries: 2);
            Console.WriteLine("Success: " + result[..Math.Min(100, result?.Length ?? 0)]);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Final failure: " + ex.Message);
        }
    }
}
