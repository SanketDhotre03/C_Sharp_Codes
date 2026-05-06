// Program: AsyncHttpRequest
// Difficulty: Medium
// Description: Makes asynchronous HTTP GET request using HttpClient.
using System;
using System.Net.Http;
using System.Threading.Tasks;

class AsyncHttpRequest
{
    static async Task Main(string[] args)
    {
        // Using a reliable public API for demonstration
        string url = "https://httpbin.org/get";
        Console.WriteLine($"Requesting: {url}");

        try
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            var response = await client.GetAsync(url);
            Console.WriteLine($"Status: {response.StatusCode}");
            string body = await response.Content.ReadAsStringAsync();
            // Print just first 200 chars
            Console.WriteLine(body.Length > 200 ? body[..200] + "..." : body);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request failed (no network?): {ex.Message}");
        }
    }
}
