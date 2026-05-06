// Program: WriteBinaryFile
// Difficulty: Medium
// Description: Writes structured binary data to a file.
using System;
using System.IO;

class WriteBinaryFile
{
    struct Record
    {
        public int Id;
        public string Name;
        public double Score;
    }

    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "records.bin");
        var records = new[] {
            new Record { Id = 1, Name = "Alice", Score = 95.5 },
            new Record { Id = 2, Name = "Bob",   Score = 87.3 },
            new Record { Id = 3, Name = "Carol", Score = 92.1 }
        };

        using (var bw = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            bw.Write(records.Length);
            foreach (var r in records) { bw.Write(r.Id); bw.Write(r.Name); bw.Write(r.Score); }
        }

        Console.WriteLine("Wrote binary file. Reading back:");
        using var br = new BinaryReader(File.Open(path, FileMode.Open));
        int count = br.ReadInt32();
        for (int i = 0; i < count; i++)
            Console.WriteLine($"  Id={br.ReadInt32()}, Name={br.ReadString()}, Score={br.ReadDouble():F1}");

        File.Delete(path);
    }
}
