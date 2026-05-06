// Program: FileCompression
// Difficulty: High
// Description: Compresses and decompresses data using GZip.
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

class FileCompression
{
    static byte[] Compress(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        using var output = new MemoryStream();
        using (var gz = new GZipStream(output, CompressionLevel.Optimal))
            gz.Write(bytes, 0, bytes.Length);
        return output.ToArray();
    }

    static string Decompress(byte[] compressed)
    {
        using var input = new MemoryStream(compressed);
        using var gz = new GZipStream(input, CompressionMode.Decompress);
        using var output = new MemoryStream();
        gz.CopyTo(output);
        return Encoding.UTF8.GetString(output.ToArray());
    }

    static void Main(string[] args)
    {
        string original = string.Join("\n", System.Linq.Enumerable.Repeat(
            "The quick brown fox jumps over the lazy dog.", 20));
        byte[] compressed = Compress(original);
        string restored = Decompress(compressed);

        Console.WriteLine($"Original size:   {Encoding.UTF8.GetByteCount(original)} bytes");
        Console.WriteLine($"Compressed size: {compressed.Length} bytes");
        Console.WriteLine($"Ratio: {(double)compressed.Length / Encoding.UTF8.GetByteCount(original):P1}");
        Console.WriteLine($"Restored matches: {original == restored}");
    }
}
