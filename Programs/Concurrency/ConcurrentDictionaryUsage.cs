// Program: ConcurrentDictionaryUsage
// Difficulty: Medium
// Description: Thread-safe dictionary operations using ConcurrentDictionary.
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

class ConcurrentDictionaryUsage
{
    static async Task Main(string[] args)
    {
        var wordCount = new ConcurrentDictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        string[] words = { "apple", "banana", "apple", "cherry", "banana", "apple", "date" };

        var tasks = words.Select(w => Task.Run(() =>
            wordCount.AddOrUpdate(w, 1, (key, old) => old + 1)));
        await Task.WhenAll(tasks);

        foreach (var kv in wordCount.OrderBy(kv => kv.Key))
            Console.WriteLine($"  {kv.Key}: {kv.Value}");

        wordCount.TryAdd("elderberry", 1);
        wordCount.GetOrAdd("fig", 0);
        Console.WriteLine($"Keys: {wordCount.Count}");
    }
}
