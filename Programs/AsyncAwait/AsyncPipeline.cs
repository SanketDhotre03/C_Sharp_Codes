// Program: AsyncPipeline
// Difficulty: High
// Description: Demonstrates async data pipeline with chained transformations.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class AsyncPipeline
{
    static async IAsyncEnumerable<int> GenerateNumbers(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            await Task.Delay(10);
            yield return i;
        }
    }

    static async IAsyncEnumerable<int> FilterEven(IAsyncEnumerable<int> source)
    {
        await foreach (var n in source)
            if (n % 2 == 0) yield return n;
    }

    static async IAsyncEnumerable<int> MultiplyByThree(IAsyncEnumerable<int> source)
    {
        await foreach (var n in source) yield return n * 3;
    }

    static async Task Main(string[] args)
    {
        var pipeline = MultiplyByThree(FilterEven(GenerateNumbers(10)));
        Console.Write("Pipeline result: ");
        await foreach (var n in pipeline) Console.Write(n + " ");
        Console.WriteLine();
    }
}
