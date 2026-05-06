// Program: BinarySerialize
// Difficulty: Medium
// Description: Serializes objects to binary format using manual BinaryWriter.
using System;
using System.IO;

class BinarySerialize
{
    record Student(int Id, string Name, double GPA, bool IsActive);

    static void Serialize(Student s, BinaryWriter bw)
    {
        bw.Write(s.Id); bw.Write(s.Name); bw.Write(s.GPA); bw.Write(s.IsActive);
    }

    static Student Deserialize(BinaryReader br)
    {
        return new Student(br.ReadInt32(), br.ReadString(), br.ReadDouble(), br.ReadBoolean());
    }

    static void Main(string[] args)
    {
        var original = new Student(1, "Alice", 3.9, true);
        using var ms = new MemoryStream();
        using (var bw = new BinaryWriter(ms, System.Text.Encoding.UTF8, leaveOpen: true))
            Serialize(original, bw);

        ms.Position = 0;
        using var br = new BinaryReader(ms);
        var restored = Deserialize(br);

        Console.WriteLine($"Original:  {original}");
        Console.WriteLine($"Restored:  {restored}");
        Console.WriteLine($"Equal: {original == restored}");
        Console.WriteLine($"Bytes: {ms.Length}");
    }
}
