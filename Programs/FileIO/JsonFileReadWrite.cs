// Program: JsonFileReadWrite
// Difficulty: Medium
// Description: Reads and writes JSON files using System.Text.Json.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

class JsonFileReadWrite
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public List<string> Courses { get; set; }
    }

    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "students.json");
        var students = new List<Student> {
            new Student { Id=1, Name="Alice", GPA=3.9, Courses=new List<string>{"Math","CS"} },
            new Student { Id=2, Name="Bob",   GPA=3.5, Courses=new List<string>{"Physics","CS"} }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(students, options);
        File.WriteAllText(path, json);
        Console.WriteLine("Written JSON:");
        Console.WriteLine(json);

        string readBack = File.ReadAllText(path);
        var loaded = JsonSerializer.Deserialize<List<Student>>(readBack);
        Console.WriteLine($"\nLoaded {loaded.Count} students:");
        foreach (var s in loaded)
            Console.WriteLine($"  {s.Name} (GPA: {s.GPA}): {string.Join(", ", s.Courses)}");

        File.Delete(path);
    }
}
