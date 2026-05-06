// Program: CsvWriter
// Difficulty: Medium
// Description: Writes data to CSV format.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class CsvWriter
{
    record Employee(int Id, string Name, string Department, decimal Salary);

    static void WriteCsv(string path, IEnumerable<Employee> employees)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Id,Name,Department,Salary");
        foreach (var e in employees)
            sb.AppendLine($"{e.Id},{EscapeCsv(e.Name)},{e.Department},{e.Salary:F2}");
        File.WriteAllText(path, sb.ToString());
    }

    static string EscapeCsv(string s) => s.Contains(',') ? $"\"{s}\"" : s;

    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "employees.csv");
        var data = new[] {
            new Employee(1, "Alice Smith", "Engineering", 85000m),
            new Employee(2, "Bob Jones",   "Marketing",   70000m),
            new Employee(3, "Carol, Lee",  "HR",          65000m)
        };
        WriteCsv(path, data);
        Console.WriteLine("CSV written:");
        Console.WriteLine(File.ReadAllText(path));
        File.Delete(path);
    }
}
