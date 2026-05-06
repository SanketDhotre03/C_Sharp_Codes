// Program: HttpClientHeaders
// Difficulty: Medium
// Description: Demonstrates setting custom headers in HttpClient requests.
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class HttpClientHeaders
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient();

        // Set default headers
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("X-Custom-Header", "MyValue");
        client.DefaultRequestHeaders.UserAgent.ParseAdd("CSharp-HttpClient/1.0");

        // Add Authorization header
        string fakeToken = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("user:pass"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", fakeToken);

        Console.WriteLine("Request headers:");
        foreach (var h in client.DefaultRequestHeaders)
            Console.WriteLine($"  {h.Key}: {string.Join(", ", h.Value)}");

        try
        {
            var response = await client.GetAsync("https://httpbin.org/headers");
            string body = await response.Content.ReadAsStringAsync();
            Console.WriteLine("
Server received headers (snippet):");
            Console.WriteLine(body.Length > 300 ? body[..300] : body);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Network error: " + ex.Message);
        }
    }
}
