// Program: ReadTextFile
// Difficulty: Medium
// Description: Reads a text file using various methods.
using System;
using System.IO;

class ReadTextFile
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "sample.txt");
        File.WriteAllText(path, "Hello World\nLine 2\nLine 3");

        // Method 1: ReadAllText
        string content = File.ReadAllText(path);
        Console.WriteLine("All text:\n" + content);

        // Method 2: ReadAllLines
        string[] lines = File.ReadAllLines(path);
        Console.WriteLine($"\nLine count: {lines.Length}");
        foreach (var line in lines) Console.WriteLine("  > " + line);

        // Method 3: StreamReader
        using var reader = new StreamReader(path);
        Console.WriteLine("\nStreamReader:");
        while (!reader.EndOfStream)
            Console.WriteLine("  " + reader.ReadLine());

        File.Delete(path);
    }
}
