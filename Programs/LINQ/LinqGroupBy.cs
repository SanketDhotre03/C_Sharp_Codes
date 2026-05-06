// Program: LinqGroupBy
// Difficulty: Medium
// Description: Groups elements using LINQ GroupBy.
using System;
using System.Linq;

class LinqGroupBy
{
    record Student(string Name, string Grade);

    static void Main(string[] args)
    {
        var students = new[] {
            new Student("Alice", "A"), new Student("Bob", "B"),
            new Student("Charlie", "A"), new Student("Diana", "C"),
            new Student("Eve", "B"), new Student("Frank", "A")
        };
        var groups = students.GroupBy(s => s.Grade).OrderBy(g => g.Key);
        foreach (var g in groups)
        {
            Console.WriteLine($"Grade {g.Key}:");
            foreach (var s in g) Console.WriteLine($"  {s.Name}");
        }
    }
}
