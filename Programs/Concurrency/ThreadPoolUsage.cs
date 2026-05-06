// Program: ThreadPoolUsage
// Difficulty: Medium
// Description: Uses ThreadPool for executing work items asynchronously.
using System;
using System.Threading;

class ThreadPoolUsage
{
    static CountdownEvent countdown;

    static void ProcessItem(object state)
    {
        int id = (int)state;
        Console.WriteLine($"Processing item {id} on thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(100);
        countdown.Signal();
    }

    static void Main(string[] args)
    {
        int itemCount = 5;
        countdown = new CountdownEvent(itemCount);
        Console.WriteLine($"ThreadPool workers: {ThreadPool.ThreadCount}");
        for (int i = 1; i <= itemCount; i++)
            ThreadPool.QueueUserWorkItem(ProcessItem, i);
        countdown.Wait();
        Console.WriteLine("All items processed.");
    }
}
