// Program: AsyncWhenAny
// Difficulty: Medium
// Description: Races multiple tasks and takes the first to complete using WhenAny.
using System;
using System.Threading.Tasks;

class AsyncWhenAny
{
    static async Task<string> SlowService(int delay, string name)
    {
        await Task.Delay(delay);
        return $"Response from {name}";
    }

    static async Task Main(string[] args)
    {
        var t1 = SlowService(300, "Server1");
        var t2 = SlowService(100, "Server2");
        var t3 = SlowService(200, "Server3");
        var fastest = await Task.WhenAny(t1, t2, t3);
        Console.WriteLine("Fastest: " + await fastest);
    }
}
