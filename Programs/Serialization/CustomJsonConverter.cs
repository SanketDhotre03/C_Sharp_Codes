// Program: CustomJsonConverter
// Difficulty: High
// Description: Creates a custom JSON converter for special types.
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

class CustomJsonConverter
{
    class DateOnlyConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateTime.ParseExact(reader.GetString(), "yyyy-MM-dd", null);

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }

    class Event
    {
        public string Name { get; set; }
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }

    static void Main(string[] args)
    {
        var ev = new Event { Name = "Tech Conference", Date = new DateTime(2024, 6, 15), Location = "NYC" };
        var opts = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(ev, opts);
        Console.WriteLine("Serialized:");
        Console.WriteLine(json);

        var restored = JsonSerializer.Deserialize<Event>(json, opts);
        Console.WriteLine($"\nRestored: {restored.Name} on {restored.Date:D}");
    }
}
