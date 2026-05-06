// Program: DirectoryOperations
// Difficulty: Medium
// Description: Demonstrates directory creation, listing, and deletion.
using System;
using System.IO;

class DirectoryOperations
{
    static void Main(string[] args)
    {
        string baseDir = Path.Combine(Path.GetTempPath(), "test_dir_" + Guid.NewGuid().ToString("N")[..8]);
        Directory.CreateDirectory(baseDir);
        Directory.CreateDirectory(Path.Combine(baseDir, "sub1"));
        Directory.CreateDirectory(Path.Combine(baseDir, "sub2"));
        File.WriteAllText(Path.Combine(baseDir, "readme.txt"), "Root file");
        File.WriteAllText(Path.Combine(baseDir, "sub1", "data.txt"), "Sub1 file");

        Console.WriteLine("Directory structure:");
        void PrintDir(string path, string indent = "")
        {
            Console.WriteLine($"{indent}{Path.GetFileName(path)}/");
            foreach (var d in Directory.GetDirectories(path)) PrintDir(d, indent + "  ");
            foreach (var f in Directory.GetFiles(path)) Console.WriteLine($"{indent}  {Path.GetFileName(f)}");
        }
        PrintDir(baseDir);

        Console.WriteLine($"\nDirectory exists: {Directory.Exists(baseDir)}");
        Directory.Delete(baseDir, recursive: true);
        Console.WriteLine($"After delete exists: {Directory.Exists(baseDir)}");
    }
}
