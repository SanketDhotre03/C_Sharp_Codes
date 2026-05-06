// Program: ConcurrentStackUsage
// Difficulty: Medium
// Description: Thread-safe stack using ConcurrentStack.
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

class ConcurrentStackUsage
{
    static async Task Main(string[] args)
    {
        var stack = new ConcurrentStack<int>();

        var pushers = Enumerable.Range(0, 3).Select(t => Task.Run(() => {
            for (int i = 1; i <= 3; i++)
            {
                int val = t * 10 + i;
                stack.Push(val);
                Console.WriteLine($"Pushed: {val}");
            }
        }));

        await Task.WhenAll(pushers);
        Console.WriteLine($"Stack count: {stack.Count}");

        while (stack.TryPop(out int v))
            Console.Write(v + " ");
        Console.WriteLine();
    }
}
