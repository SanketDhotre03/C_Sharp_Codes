// Program: ReaderWriterLock
// Difficulty: High
// Description: Allows multiple readers or one writer using ReaderWriterLockSlim.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class SharedResource
{
    ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
    Dictionary<string, string> data = new Dictionary<string, string>();

    public string Read(string key)
    {
        rwLock.EnterReadLock();
        try { return data.TryGetValue(key, out string v) ? v : null; }
        finally { rwLock.ExitReadLock(); }
    }

    public void Write(string key, string value)
    {
        rwLock.EnterWriteLock();
        try { data[key] = value; }
        finally { rwLock.ExitWriteLock(); }
    }
}

class ReaderWriterLock
{
    static SharedResource resource = new SharedResource();

    static async Task Main(string[] args)
    {
        resource.Write("key1", "initial");
        var readers = Enumerable.Range(1, 4).Select(i => Task.Run(() => {
            Console.WriteLine($"Reader {i}: {resource.Read("key1")}");
        }));
        var writer = Task.Run(() => { Thread.Sleep(50); resource.Write("key1", "updated"); Console.WriteLine("Written: updated"); });
        await Task.WhenAll(readers.Append(writer));
        Console.WriteLine($"Final: {resource.Read("key1")}");
    }
}
