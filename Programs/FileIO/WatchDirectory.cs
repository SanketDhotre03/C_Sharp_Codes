// Program: WatchDirectory
// Difficulty: High
// Description: Monitors a directory for file changes using FileSystemWatcher.
using System;
using System.IO;
using System.Threading;

class WatchDirectory
{
    static void Main(string[] args)
    {
        string dir = Path.Combine(Path.GetTempPath(), "watch_test_" + Guid.NewGuid().ToString("N")[..6]);
        Directory.CreateDirectory(dir);

        using var watcher = new FileSystemWatcher(dir)
        {
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size,
            Filter = "*.txt",
            EnableRaisingEvents = true
        };

        watcher.Created += (s, e) => Console.WriteLine($"Created: {e.Name}");
        watcher.Changed += (s, e) => Console.WriteLine($"Changed: {e.Name}");
        watcher.Deleted += (s, e) => Console.WriteLine($"Deleted: {e.Name}");

        Console.WriteLine($"Watching: {dir}");
        File.WriteAllText(Path.Combine(dir, "test.txt"), "initial");
        Thread.Sleep(100);
        File.AppendAllText(Path.Combine(dir, "test.txt"), " updated");
        Thread.Sleep(100);
        File.Delete(Path.Combine(dir, "test.txt"));
        Thread.Sleep(200);

        Directory.Delete(dir, recursive: true);
        Console.WriteLine("Done watching.");
    }
}
