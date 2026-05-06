// Program: JsonIgnoreProperty
// Difficulty: Medium
// Description: Demonstrates JSON attribute customization with System.Text.Json.
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

class JsonIgnoreProperty
{
    class User
    {
        [JsonPropertyName("user_name")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PhoneNumber { get; set; }

        [JsonPropertyOrder(1)]
        public int Age { get; set; }
    }

    static void Main(string[] args)
    {
        var user = new User
        {
            Username = "alice99",
            Email = "alice@example.com",
            Password = "super_secret_123",
            PhoneNumber = null,
            Age = 30
        };

        string json = JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("Serialized (password hidden, null phone omitted):");
        Console.WriteLine(json);
    }
}
