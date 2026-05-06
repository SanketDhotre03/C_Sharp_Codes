// Program: WriteTextFile
// Difficulty: Medium
// Description: Writes text to files using various methods.
using System;
using System.IO;

class WriteTextFile
{
    static void Main(string[] args)
    {
        string dir = Path.GetTempPath();

        // Method 1: WriteAllText
        string path1 = Path.Combine(dir, "file1.txt");
        File.WriteAllText(path1, "Hello, World!");
        Console.WriteLine("Wrote file1.txt");

        // Method 2: WriteAllLines
        string path2 = Path.Combine(dir, "file2.txt");
        File.WriteAllLines(path2, new[] { "Line 1", "Line 2", "Line 3" });
        Console.WriteLine("Wrote file2.txt");

        // Method 3: StreamWriter
        string path3 = Path.Combine(dir, "file3.txt");
        using (var writer = new StreamWriter(path3))
        {
            writer.WriteLine("StreamWriter line 1");
            writer.Write("No newline");
            writer.WriteLine(" continued");
        }
        Console.WriteLine("Wrote file3.txt");

        Console.WriteLine("\nContents:");
        Console.WriteLine(File.ReadAllText(path2));

        foreach (var p in new[]{path1,path2,path3}) File.Delete(p);
    }
}
