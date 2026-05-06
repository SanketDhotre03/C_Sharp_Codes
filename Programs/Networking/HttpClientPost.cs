// Program: HttpClientPost
// Difficulty: Medium
// Description: Makes HTTP POST requests with JSON body using HttpClient.
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class HttpClientPost
{
    record PostData(string Title, string Body, int UserId);

    static async Task Main(string[] args)
    {
        using var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(10);

        var data = new PostData("Test Post", "This is a test body.", 1);
        string json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        string url = "https://jsonplaceholder.typicode.com/posts";
        Console.WriteLine($"POST {url}");
        Console.WriteLine("Body: " + json);
        try
        {
            var response = await client.PostAsync(url, content);
            Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
            string body = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response: " + body);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error (no network?): {ex.Message}");
        }
    }
}
