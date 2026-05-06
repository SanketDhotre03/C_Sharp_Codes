// Program: LinqMin
// Difficulty: Medium
// Description: Finds minimum values using LINQ Min.
using System;
using System.Linq;

class LinqMin
{
    record Employee(string Name, decimal Salary);

    static void Main(string[] args)
    {
        int[] nums = { 5, 2, 8, 1, 9, 3 };
        Console.WriteLine($"Min: {nums.Min()}");
        Console.WriteLine($"Min square: {nums.Min(n => n * n)}");

        var employees = new[] {
            new Employee("Alice", 75000m), new Employee("Bob", 60000m),
            new Employee("Charlie", 90000m)
        };
        decimal minSalary = employees.Min(e => e.Salary);
        string lowestPaid = employees.First(e => e.Salary == minSalary).Name;
        Console.WriteLine($"Lowest salary: ${minSalary} ({lowestPaid})");
    }
}
