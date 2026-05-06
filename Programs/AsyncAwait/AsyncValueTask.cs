// Program: AsyncValueTask
// Difficulty: High
// Description: Uses ValueTask for performance-optimized async operations.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Cache<T>
{
    Dictionary<string, T> _cache = new Dictionary<string, T>();

    public ValueTask<T> GetOrFetchAsync(string key, Func<Task<T>> fetch)
    {
        if (_cache.TryGetValue(key, out T value))
            return new ValueTask<T>(value);  // synchronous path - no allocation
        return new ValueTask<T>(FetchAndCache(key, fetch));
    }

    async Task<T> FetchAndCache(string key, Func<Task<T>> fetch)
    {
        T value = await fetch();
        _cache[key] = value;
        return value;
    }
}

class AsyncValueTask
{
    static async Task<string> FetchFromDB(string id)
    {
        await Task.Delay(100);
        return $"Data for {id}";
    }

    static async Task Main(string[] args)
    {
        var cache = new Cache<string>();
        var r1 = await cache.GetOrFetchAsync("user1", () => FetchFromDB("user1"));
        Console.WriteLine("First call: " + r1);
        var r2 = await cache.GetOrFetchAsync("user1", () => FetchFromDB("user1"));
        Console.WriteLine("Cached call: " + r2);
    }
}
