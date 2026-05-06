// Program: ThreadBasics
// Difficulty: Medium
// Description: Demonstrates creating and managing threads in C#.
using System;
using System.Threading;

class ThreadBasics
{
    static void PrintNumbers(string name)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{name}: {i}");
            Thread.Sleep(100);
        }
    }

    static void Main(string[] args)
    {
        var t1 = new Thread(() => PrintNumbers("Thread-1"));
        var t2 = new Thread(() => PrintNumbers("Thread-2"));
        t1.IsBackground = true;
        t2.IsBackground = true;
        t1.Start(); t2.Start();
        t1.Join(); t2.Join();
        Console.WriteLine("All threads done.");
    }
}
