// Program: BlockingCollection
// Difficulty: High
// Description: Bounded blocking collection for producer-consumer pattern.
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class BlockingCollection
{
    static async Task Main(string[] args)
    {
        var collection = new BlockingCollection<int>(boundedCapacity: 3);

        var producer = Task.Run(() => {
            for (int i = 1; i <= 7; i++)
            {
                collection.Add(i);
                Console.WriteLine($"Produced: {i} (count: {collection.Count})");
                Thread.Sleep(80);
            }
            collection.CompleteAdding();
        });

        var consumer = Task.Run(() => {
            foreach (var item in collection.GetConsumingEnumerable())
            {
                Thread.Sleep(150);
                Console.WriteLine($"  Consumed: {item}");
            }
        });

        await Task.WhenAll(producer, consumer);
        Console.WriteLine("Producer-Consumer done.");
    }
}
