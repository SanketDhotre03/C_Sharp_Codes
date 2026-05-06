// Program: MutexExample
// Difficulty: Medium
// Description: Demonstrates a Mutex for mutual exclusion across threads.
using System;
using System.Threading;

class MutexExample
{
    static Mutex mutex = new Mutex();
    static int sharedCounter = 0;

    static void Increment(int threadId)
    {
        for (int i = 0; i < 5; i++)
        {
            mutex.WaitOne();
            try
            {
                int temp = sharedCounter;
                Thread.Sleep(10);
                sharedCounter = temp + 1;
                Console.WriteLine($"Thread {threadId}: counter = {sharedCounter}");
            }
            finally { mutex.ReleaseMutex(); }
        }
    }

    static void Main(string[] args)
    {
        var t1 = new Thread(() => Increment(1));
        var t2 = new Thread(() => Increment(2));
        t1.Start(); t2.Start();
        t1.Join(); t2.Join();
        Console.WriteLine($"Final counter: {sharedCounter}");
    }
}
