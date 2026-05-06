// Program: ReadBinaryFile
// Difficulty: Medium
// Description: Reads binary data from a file using BinaryReader.
using System;
using System.IO;

class ReadBinaryFile
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "data.bin");

        // Write some binary data first
        using (var bw = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            bw.Write(42);            // int
            bw.Write(3.14);          // double
            bw.Write("Hello");       // string
            bw.Write(true);          // bool
            bw.Write((byte)255);     // byte
        }

        // Read the binary data back
        using var br = new BinaryReader(File.Open(path, FileMode.Open));
        Console.WriteLine($"Int:    {br.ReadInt32()}");
        Console.WriteLine($"Double: {br.ReadDouble():F2}");
        Console.WriteLine($"String: {br.ReadString()}");
        Console.WriteLine($"Bool:   {br.ReadBoolean()}");
        Console.WriteLine($"Byte:   {br.ReadByte()}");

        File.Delete(path);
    }
}
