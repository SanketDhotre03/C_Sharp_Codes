// Program: JsonSerialize
// Difficulty: Medium
// Description: Serializes C# objects to JSON using System.Text.Json.
using System;
using System.Collections.Generic;
using System.Text.Json;

class JsonSerialize
{
    record Address(string Street, string City, string Country);
    record Person(string Name, int Age, Address Address, List<string> Hobbies);

    static void Main(string[] args)
    {
        var person = new Person(
            "Alice Johnson", 30,
            new Address("123 Main St", "New York", "USA"),
            new List<string> { "Reading", "Hiking", "Coding" });

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(person, options);
        Console.WriteLine(json);
    }
}
