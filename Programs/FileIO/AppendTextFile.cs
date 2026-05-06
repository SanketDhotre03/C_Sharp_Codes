// Program: AppendTextFile
// Difficulty: Medium
// Description: Appends text to existing files.
using System;
using System.IO;

class AppendTextFile
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "log.txt");
        File.WriteAllText(path, "=== Log File ===\n");

        // Append individual lines
        for (int i = 1; i <= 3; i++)
        {
            File.AppendAllText(path, $"[{DateTime.Now:HH:mm:ss}] Log entry {i}\n");
            System.Threading.Thread.Sleep(10);
        }

        // Append with StreamWriter
        using (var sw = new StreamWriter(path, append: true))
            sw.WriteLine($"[{DateTime.Now:HH:mm:ss}] Final entry");

        Console.WriteLine(File.ReadAllText(path));
        File.Delete(path);
    }
}
