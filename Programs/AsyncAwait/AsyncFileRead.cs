// Program: AsyncFileRead
// Difficulty: Medium
// Description: Reads and writes files asynchronously.
using System;
using System.IO;
using System.Threading.Tasks;

class AsyncFileRead
{
    static async Task Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "async_test.txt");
        string content = string.Join(Environment.NewLine,
            new[] { "Line 1", "Line 2", "Line 3", "Line 4", "Line 5" });

        await File.WriteAllTextAsync(path, content);
        Console.WriteLine("Written to file.");

        string read = await File.ReadAllTextAsync(path);
        Console.WriteLine("Read from file:");
        Console.WriteLine(read);

        string[] lines = await File.ReadAllLinesAsync(path);
        Console.WriteLine($"
Total lines: {lines.Length}");

        File.Delete(path);
    }
}
