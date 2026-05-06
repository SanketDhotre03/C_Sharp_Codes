// Program: JsonList
// Difficulty: Medium
// Description: Serializes and deserializes JSON arrays/lists.
using System;
using System.Collections.Generic;
using System.Text.Json;

class JsonList
{
    record Color(string Name, string Hex, int R, int G, int B);

    static void Main(string[] args)
    {
        var colors = new List<Color>
        {
            new Color("Red",   "#FF0000", 255, 0, 0),
            new Color("Green", "#00FF00", 0, 255, 0),
            new Color("Blue",  "#0000FF", 0, 0, 255),
            new Color("White", "#FFFFFF", 255, 255, 255)
        };

        string json = JsonSerializer.Serialize(colors, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("JSON Array:");
        Console.WriteLine(json);

        var restored = JsonSerializer.Deserialize<List<Color>>(json);
        Console.WriteLine($"\nRestored {restored.Count} colors:");
        foreach (var c in restored)
            Console.WriteLine($"  {c.Name}: {c.Hex} (R={c.R}, G={c.G}, B={c.B})");
    }
}
