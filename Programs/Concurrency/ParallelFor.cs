// Program: ParallelFor
// Difficulty: Medium
// Description: Demonstrates Parallel.For for data parallelism.
using System;
using System.Threading;
using System.Threading.Tasks;

class ParallelFor
{
    static void Main(string[] args)
    {
        int[] data = new int[20];
        Console.WriteLine("Processing items in parallel:");
        Parallel.For(0, data.Length, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i => {
            data[i] = i * i;
            Console.WriteLine($"  data[{i}] = {data[i]} (Thread {Thread.CurrentThread.ManagedThreadId})");
        });
        Console.WriteLine("Result: " + string.Join(", ", data));
    }
}
