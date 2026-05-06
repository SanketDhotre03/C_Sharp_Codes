// Program: JsonNested
// Difficulty: Medium
// Description: Serializes and deserializes deeply nested JSON structures.
using System;
using System.Collections.Generic;
using System.Text.Json;

class JsonNested
{
    class Company
    {
        public string Name { get; set; }
        public Address HQ { get; set; }
        public List<Department> Departments { get; set; }
    }
    class Address { public string Street { get; set; } public string City { get; set; } }
    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
    class Employee { public string Name { get; set; } public string Title { get; set; } }

    static void Main(string[] args)
    {
        var company = new Company
        {
            Name = "TechCorp",
            HQ = new Address { Street = "1 Main St", City = "Austin" },
            Departments = new List<Department>
            {
                new Department { Name = "Engineering", Employees = new List<Employee>
                    { new Employee { Name="Alice", Title="SWE" }, new Employee { Name="Bob", Title="Lead" } }},
                new Department { Name = "Design", Employees = new List<Employee>
                    { new Employee { Name="Carol", Title="Designer" } }}
            }
        };

        string json = JsonSerializer.Serialize(company, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
        var c2 = JsonSerializer.Deserialize<Company>(json);
        Console.WriteLine($"\nRestored: {c2.Name} with {c2.Departments.Count} departments");
    }
}
