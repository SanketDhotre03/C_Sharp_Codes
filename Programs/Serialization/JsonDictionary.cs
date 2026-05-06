// Program: JsonDictionary
// Difficulty: Medium
// Description: Serializes and deserializes dictionaries to/from JSON.
using System;
using System.Collections.Generic;
using System.Text.Json;

class JsonDictionary
{
    static void Main(string[] args)
    {
        // Dictionary<string, object>
        var config = new Dictionary<string, object>
        {
            ["host"] = "localhost",
            ["port"] = 5432,
            ["database"] = "mydb",
            ["ssl"] = true,
            ["timeout"] = 30
        };

        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("Config JSON:");
        Console.WriteLine(json);

        // Deserialize back
        var restored = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
        Console.WriteLine("\nRestored:");
        foreach (var kv in restored)
            Console.WriteLine($"  {kv.Key} = {kv.Value} ({kv.Value.ValueKind})");
    }
}
