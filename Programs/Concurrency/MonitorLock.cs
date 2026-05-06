// Program: MonitorLock
// Difficulty: Medium
// Description: Demonstrates Monitor/lock for thread synchronization.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class SafeQueue<T>
{
    Queue<T> queue = new Queue<T>();
    object lockObj = new object();

    public void Enqueue(T item) { lock (lockObj) { queue.Enqueue(item); Console.WriteLine($"  Enqueued: {item}"); } }
    public bool TryDequeue(out T item) { lock (lockObj) { if (queue.Count > 0) { item = queue.Dequeue(); return true; } item = default; return false; } }
    public int Count { get { lock (lockObj) return queue.Count; } }
}

class MonitorLock
{
    static async Task Main(string[] args)
    {
        var q = new SafeQueue<int>();
        var producer = Task.Run(() => { for (int i = 1; i <= 5; i++) { q.Enqueue(i); Thread.Sleep(50); } });
        var consumer = Task.Run(() => { Thread.Sleep(100); while (q.Count > 0 || true) { if (q.TryDequeue(out int v)) Console.WriteLine($"Dequeued: {v}"); else break; Thread.Sleep(75); } });
        await Task.WhenAll(producer, consumer);
    }
}
