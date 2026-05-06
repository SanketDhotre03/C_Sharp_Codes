// Program: ConcurrentQueueUsage
// Difficulty: Medium
// Description: Thread-safe queue using ConcurrentQueue.
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class ConcurrentQueueUsage
{
    static async Task Main(string[] args)
    {
        var queue = new ConcurrentQueue<string>();
        var produced = 0;

        var producer = Task.Run(() => {
            for (int i = 1; i <= 5; i++)
            {
                queue.Enqueue($"item-{i}");
                Console.WriteLine($"Produced item-{i}");
                System.Threading.Thread.Sleep(50);
            }
        });

        var consumer = Task.Run(async () => {
            await Task.Delay(100);
            while (produced < 5)
            {
                if (queue.TryDequeue(out string item))
                {
                    Console.WriteLine($"  Consumed {item}");
                    produced++;
                }
                await Task.Delay(30);
            }
        });

        await Task.WhenAll(producer, consumer);
    }
}
