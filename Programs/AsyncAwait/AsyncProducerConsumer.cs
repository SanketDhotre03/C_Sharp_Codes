// Program: AsyncProducerConsumer
// Difficulty: High
// Description: Async producer-consumer pattern using Channel<T>.
using System;
using System.Threading.Channels;
using System.Threading.Tasks;

class AsyncProducerConsumer
{
    static async Task Produce(ChannelWriter<int> writer, int count)
    {
        for (int i = 1; i <= count; i++)
        {
            await writer.WriteAsync(i);
            Console.WriteLine($"Produced: {i}");
            await Task.Delay(50);
        }
        writer.Complete();
    }

    static async Task Consume(ChannelReader<int> reader)
    {
        await foreach (var item in reader.ReadAllAsync())
        {
            await Task.Delay(30);
            Console.WriteLine($"  Consumed: {item * 2}");
        }
    }

    static async Task Main(string[] args)
    {
        var channel = Channel.CreateBounded<int>(3);
        var producer = Produce(channel.Writer, 5);
        var consumer = Consume(channel.Reader);
        await Task.WhenAll(producer, consumer);
        Console.WriteLine("Done.");
    }
}
