// Program: HttpClientGet
// Difficulty: Medium
// Description: Makes HTTP GET requests using HttpClient.
using System;
using System.Net.Http;
using System.Threading.Tasks;

class HttpClientGet
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "CSharp-Example/1.0");
        client.Timeout = TimeSpan.FromSeconds(10);

        string url = "https://httpbin.org/get";
        Console.WriteLine($"GET {url}");
        try
        {
            var response = await client.GetAsync(url);
            Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
            Console.WriteLine("Headers:");
            foreach (var h in response.Headers)
                Console.WriteLine($"  {h.Key}: {string.Join(", ", h.Value)}");
            string body = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Body (first 300 chars):");
            Console.WriteLine(body.Length > 300 ? body[..300] + "..." : body);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error (no network?): {ex.Message}");
        }
    }
}
