using System;
using System.Threading.Tasks;

class Program49
{
    static async Task Main()
    {
        Console.WriteLine("Processing...");
        await Task.Delay(500);
        Console.WriteLine("Done");
    }
}
