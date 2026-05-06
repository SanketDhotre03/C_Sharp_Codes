// Program: LinqMax
// Difficulty: Medium
// Description: Finds maximum values using LINQ Max.
using System;
using System.Linq;

class LinqMax
{
    record Employee(string Name, decimal Salary);

    static void Main(string[] args)
    {
        int[] nums = { 5, 2, 8, 1, 9, 3 };
        Console.WriteLine($"Max: {nums.Max()}");
        Console.WriteLine($"Max of subset (>5): {nums.Where(n => n > 5).Max()}");

        var employees = new[] {
            new Employee("Alice", 75000m), new Employee("Bob", 60000m),
            new Employee("Charlie", 90000m)
        };
        decimal maxSalary = employees.Max(e => e.Salary);
        string highestPaid = employees.First(e => e.Salary == maxSalary).Name;
        Console.WriteLine($"Highest salary: ${maxSalary} ({highestPaid})");
    }
}
