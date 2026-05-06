// Program: BasicAsync
// Difficulty: Medium
// Description: Demonstrates basic async/await usage in C#.
using System;
using System.Threading.Tasks;

class BasicAsync
{
    static async Task<string> FetchDataAsync(string source)
    {
        Console.WriteLine($"  Fetching from {source}...");
        await Task.Delay(100); // simulate async work
        return $"Data from {source}";
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting...");
        string result = await FetchDataAsync("Server");
        Console.WriteLine("Result: " + result);
        Console.WriteLine("Done.");
    }
}
