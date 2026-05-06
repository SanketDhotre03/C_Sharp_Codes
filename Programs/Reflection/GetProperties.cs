// Program: GetProperties
// Difficulty: Medium
// Description: Reads and sets object properties dynamically using reflection.
using System;
using System.Reflection;

class GetProperties
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        private string InternalId { get; set; } = "internal";
    }

    static void PrintProperties(object obj)
    {
        Type t = obj.GetType();
        Console.WriteLine($"Properties of {t.Name}:");
        foreach (var prop in t.GetProperties())
        {
            object value = prop.GetValue(obj);
            Console.WriteLine($"  {prop.Name} ({prop.PropertyType.Name}): {value}");
        }
    }

    static void SetProperty(object obj, string propName, object value)
    {
        var prop = obj.GetType().GetProperty(propName);
        prop?.SetValue(obj, value);
    }

    static void Main(string[] args)
    {
        var person = new Person { Name = "Alice", Age = 30, Email = "alice@example.com" };
        PrintProperties(person);
        SetProperty(person, "Name", "Bob");
        SetProperty(person, "Age", 25);
        Console.WriteLine("\nAfter changes:");
        PrintProperties(person);
    }
}
