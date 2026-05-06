// Program: ObjectToJson
// Difficulty: Medium
// Description: Round-trip serialization of various object types to JSON.
using System;
using System.Text.Json;

class ObjectToJson
{
    enum Status { Active, Inactive, Pending }

    class Config
    {
        public string AppName { get; set; }
        public Version Version { get; set; }
        public DateTime Created { get; set; }
        public Status Status { get; set; }
        public double[] Thresholds { get; set; }
    }

    static void Main(string[] args)
    {
        var config = new Config
        {
            AppName = "MyApp",
            Version = new Version(2, 1, 0),
            Created = new DateTime(2024, 1, 15),
            Status = Status.Active,
            Thresholds = new double[] { 0.1, 0.5, 0.9 }
        };

        var opts = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };

        string json = JsonSerializer.Serialize(config, opts);
        Console.WriteLine(json);
    }
}
