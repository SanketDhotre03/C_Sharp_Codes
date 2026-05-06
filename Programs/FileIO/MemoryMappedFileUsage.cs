// Program: MemoryMappedFileUsage
// Difficulty: High
// Description: Uses memory-mapped files for efficient large file access.
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;

class MemoryMappedFileUsage
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "mmf_test.dat");
        long capacity = 1024;

        // Write data using memory-mapped file
        using (var mmf = MemoryMappedFile.CreateFromFile(path, FileMode.Create, null, capacity))
        using (var accessor = mmf.CreateViewAccessor())
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello, Memory Mapped Files!");
            accessor.WriteArray(0, data, 0, data.Length);
            accessor.Write(data.Length, (int)data.Length); // store length
        }

        // Read back
        using (var mmf = MemoryMappedFile.CreateFromFile(path, FileMode.Open))
        using (var accessor = mmf.CreateViewAccessor())
        {
            int len = accessor.ReadInt32(0);  // Note: simplified for demo
            byte[] buffer = new byte[26];
            accessor.ReadArray(0, buffer, 0, buffer.Length);
            Console.WriteLine("Read: " + Encoding.UTF8.GetString(buffer));
        }

        File.Delete(path);
        Console.WriteLine("Done.");
    }
}
