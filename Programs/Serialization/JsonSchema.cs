// Program: JsonSchema
// Difficulty: High
// Description: Validates JSON data structure using manual schema checking.
using System;
using System.Collections.Generic;
using System.Text.Json;

class JsonSchema
{
    static List<string> ValidateUser(JsonElement user)
    {
        var errors = new List<string>();
        if (!user.TryGetProperty("name", out var name) || name.ValueKind != JsonValueKind.String)
            errors.Add("'name' must be a string");
        if (!user.TryGetProperty("age", out var age) || age.ValueKind != JsonValueKind.Number
            || age.GetInt32() < 0 || age.GetInt32() > 150)
            errors.Add("'age' must be a number between 0 and 150");
        if (!user.TryGetProperty("email", out var email) || !email.GetString().Contains('@'))
            errors.Add("'email' must be a valid email address");
        return errors;
    }

    static void Main(string[] args)
    {
        string[] jsons = {
            @"{""name"":""Alice"",""age"":30,""email"":""alice@example.com""}",
            @"{""name"":"""",""age"":-1,""email"":""not-email""}",
            @"{""name"":""Bob"",""age"":25}"
        };
        foreach (var json in jsons)
        {
            var el = JsonDocument.Parse(json).RootElement;
            var errors = ValidateUser(el);
            Console.WriteLine($"Input: {json}");
            if (errors.Count == 0) Console.WriteLine("  Valid!");
            else foreach (var e in errors) Console.WriteLine($"  Error: {e}");
        }
    }
}
