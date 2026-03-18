using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; } = string.Empty;
    public int Marks { get; set; }
}

class Program50
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Asha", Marks = 92 },
            new Student { Name = "Ravi", Marks = 76 },
            new Student { Name = "Neha", Marks = 84 }
        };

        var toppers = students.Where(s => s.Marks >= 80).Select(s => s.Name);
        Console.WriteLine("Top students: " + string.Join(", ", toppers));
    }
}
