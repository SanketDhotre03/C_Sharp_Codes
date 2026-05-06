// Program: LinqAverage
// Difficulty: Medium
// Description: Calculates averages using LINQ Average.
using System;
using System.Linq;

class LinqAverage
{
    record Student(string Name, int Score);

    static void Main(string[] args)
    {
        double[] nums = { 2.5, 3.7, 1.8, 4.2, 5.0 };
        Console.WriteLine($"Average: {nums.Average():F2}");

        var students = new[] {
            new Student("Alice", 92), new Student("Bob", 78),
            new Student("Charlie", 85), new Student("Diana", 95)
        };
        double avg = students.Average(s => s.Score);
        Console.WriteLine($"Class average: {avg:F1}");
        var aboveAvg = students.Where(s => s.Score > avg).Select(s => s.Name);
        Console.WriteLine("Above average: " + string.Join(", ", aboveAvg));
    }
}
