// Program: JsonDeserialize
// Difficulty: Medium
// Description: Deserializes JSON strings to C# objects using System.Text.Json.
using System;
using System.Collections.Generic;
using System.Text.Json;

class JsonDeserialize
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }
        public List<string> Tags { get; set; }
    }

    static void Main(string[] args)
    {
        string json = @"{
            ""Id"": 42,
            ""Name"": ""Laptop"",
            ""Price"": 999.99,
            ""InStock"": true,
            ""Tags"": [""electronics"", ""computer"", ""portable""]
        }";
        var product = JsonSerializer.Deserialize<Product>(json);
        Console.WriteLine($"Id:       {product.Id}");
        Console.WriteLine($"Name:     {product.Name}");
        Console.WriteLine($"Price:    ${product.Price}");
        Console.WriteLine($"InStock:  {product.InStock}");
        Console.WriteLine($"Tags:     {string.Join(", ", product.Tags)}");
    }
}
