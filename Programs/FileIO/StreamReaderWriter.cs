// Program: StreamReaderWriter
// Difficulty: Medium
// Description: Uses StreamReader and StreamWriter for buffered I/O.
using System;
using System.IO;
using System.Text;

class StreamReaderWriter
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "stream_test.txt");

        // Write with StreamWriter (buffered)
        using (var sw = new StreamWriter(path, false, Encoding.UTF8, bufferSize: 4096))
        {
            sw.AutoFlush = false; // manual flush for performance
            for (int i = 1; i <= 5; i++)
                sw.WriteLine($"Line {i}: {new string('*', i)}");
            sw.Flush();
        }

        // Read with StreamReader
        using var sr = new StreamReader(path, Encoding.UTF8);
        Console.WriteLine($"Encoding: {sr.CurrentEncoding.EncodingName}");
        int lineNum = 1;
        while (!sr.EndOfStream)
            Console.WriteLine($"{lineNum++:D2}: {sr.ReadLine()}");

        File.Delete(path);
    }
}
