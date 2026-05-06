// Program: ZipArchive
// Difficulty: High
// Description: Creates and extracts ZIP archives using System.IO.Compression.
using System;
using System.IO;
using System.IO.Compression;

class ZipArchive
{
    static void Main(string[] args)
    {
        string tempDir = Path.Combine(Path.GetTempPath(), "zip_test_" + Guid.NewGuid().ToString("N")[..6]);
        string zipPath = tempDir + ".zip";
        string extractDir = tempDir + "_out";

        Directory.CreateDirectory(tempDir);
        File.WriteAllText(Path.Combine(tempDir, "file1.txt"), "Content of file 1");
        File.WriteAllText(Path.Combine(tempDir, "file2.txt"), "Content of file 2");
        File.WriteAllText(Path.Combine(tempDir, "notes.md"), "# Notes\nSome notes here.");

        // Create ZIP
        ZipFile.CreateFromDirectory(tempDir, zipPath, CompressionLevel.Optimal, false);
        Console.WriteLine($"Created ZIP: {zipPath} ({new FileInfo(zipPath).Length} bytes)");

        // List contents
        using (var zip = ZipFile.OpenRead(zipPath))
        {
            Console.WriteLine($"ZIP contains {zip.Entries.Count} entries:");
            foreach (var entry in zip.Entries)
                Console.WriteLine($"  {entry.Name} ({entry.Length} bytes)");
        }

        // Extract
        ZipFile.ExtractToDirectory(zipPath, extractDir);
        Console.WriteLine($"Extracted to: {extractDir}");
        foreach (var f in Directory.GetFiles(extractDir))
            Console.WriteLine($"  {Path.GetFileName(f)}: {File.ReadAllText(f)}");

        Directory.Delete(tempDir, true);
        Directory.Delete(extractDir, true);
        File.Delete(zipPath);
    }
}
